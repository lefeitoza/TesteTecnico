using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Domain.Entities.Request;
using Questao5.Domain.Entities.Response;

namespace Questao5.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentController : ControllerBase
    {
        private readonly IMovimentService _movimentService;
        public MovimentController(IMovimentService movimentService)
        {
            _movimentService = movimentService;
        }

        /// <summary>
        /// Insere uma movimentação na conta
        /// </summary>
        /// <remarks>
        /// Todos os valores devem ser preenchidos        
        ///  
        /// Exemplo para inserir um valor na conta corrente:
        ///
        ///     POST /Moviment
        ///     {
        ///         "id": "4f3cee96-23df-41c3-b337-a85fab81218d",
        ///         "accountNumber": 852,
        ///         "value": 52.63,
        ///         "movimentType": "C",
        ///         "success": true
        ///     }
        ///     
        /// Exemplo para inserir um débito na conta corrente
        ///     
        ///     POST /Moviment
        ///     {
        ///         "id": "4f3cee96-23df-41c3-b337-a85fab812ddd",
        ///         "accountNumber": 852,
        ///         "value": 100.63,
        ///         "movimentType": "D",
        ///         "success": true
        ///     }
        /// </remarks>
        /// <param name="movimentAccountRequest">Dados da requisição</param>
        /// <returns>Retorna o Id da movimentação</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AccountMovimentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<AccountMovimentResponse> CreateAccountMoviment([FromBody] AccountMovimentRequest movimentAccountRequest)
        {
            return new AccountMovimentResponse
            {
                MovimentId = await _movimentService.Create(movimentAccountRequest)
            };
        }

        /// <summary>
        /// Retorna o saldo atual de uma conta
        /// </summary>
        /// /// <remarks>       
        ///  
        /// Exemplo de retorno válido
        ///
        ///     GET /Moviment/Saldo/123        
        ///         {
        ///            "accountNumber": 123,
        ///            "clientName": "Katherine Sanchez",
        ///            "requestDate": "2024-07-22T01:20:12.1607574-03:00",
        ///            "accountBalance": 188.28999999999996,
        ///            "success": true
        ///         }
        ///             
        /// </remarks>
        /// <param name="accountNumber">Número da conta</param>
        /// <returns>Retorna os dados da conta e o saldo atual.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(AccountBalanceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [Route("Saldo/{accountNumber}")]
        public async Task<AccountBalanceResponse> GetAccountBalance([FromRoute] int accountNumber)
        {
            return await _movimentService.GetAccountBalanceAsync(accountNumber);
        }
    }
}
