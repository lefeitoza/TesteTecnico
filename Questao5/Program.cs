using MediatR;
using Microsoft.OpenApi.Models;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Database.Repository;
using Questao5.Infrastructure.Sqlite;
using Questao5.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddTransient<DbSession>();
builder.Services.AddSingleton<IMovimentRepository, MovimentRepository>();
builder.Services.AddSingleton<IIdempontencyRepository, IdempontencyRepository>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();


builder.Services.AddTransient<IMovimentService, MovimentService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var info = new OpenApiInfo()
{
    Title = "Documentação da API",
    Version = "v1",
    Description = "API para controle de movimentações bancárias",
    Contact = new OpenApiContact()
    {
        Name = "Leandro Feitoza",
        Email = "contato@leandrofeitoza.com.br"
    }
};
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", info);
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


