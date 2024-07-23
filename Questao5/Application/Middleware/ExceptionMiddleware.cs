using Questao5.Domain.Entities.Response;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Questao5.Application.Handlers
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, 
                                   ILogger<ExceptionMiddleware> logger, 
                                   IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            try
            {                
                await _next(context);
            }
            catch (ArgumentException ax)
            {
                _logger.LogError(ax, ax.Message);
                ErrorResponse response;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var message = ax.Message.Split("-");
                if(message.Length > 0) 
                    response = new ErrorResponse { ErrorMessage = message[0], Type = message[1], Success = false };
                else
                    response = new ErrorResponse { ErrorMessage = ax.Message, Success = false };

                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;                
                var response = new ErrorResponse { ErrorMessage = ex.Message, Success=false };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
