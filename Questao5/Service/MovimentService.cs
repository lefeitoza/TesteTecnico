using MediatR;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Domain.Entities.Request;
using Questao5.Domain.Entities.Response;
using Questao5.Domain.Enums;
using Questao5.Domain.Extensions;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Questao5.Service
{
    public class MovimentService : IMovimentService
    {
        private readonly IMediator _mediator;
        public MovimentService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Create(AccountMovimentRequest movimentAccountRequest)
        {
            try
            {
                //Validar se já houve a requisição
                var idempontency = await _mediator.Send(new FindIdempontencyByMovimentIdRequest { Id = movimentAccountRequest.Id });

                if (!string.IsNullOrEmpty(idempontency.Result))
                    return idempontency.Result;

                var account = await _mediator.Send(new FindAccountByNumberRequest { Number = movimentAccountRequest.AccountNumber });

                if(string.IsNullOrEmpty(account.Id))
                     throw new ArgumentException(string.Format("{0}-{1}", Properties.Resources.INVALID_ACCOUNT.ToString(), EValidationRules.INVALID_ACCOUNT.GetDescription()));

                if (!account.Active)
                    throw new ArgumentException(string.Format("{0}-{1}", Properties.Resources.INACTIVE_ACCOUNT.ToString(), EValidationRules.INACTIVE_ACCOUNT.GetDescription()));

                if (!(movimentAccountRequest.Value >= 0))
                    throw new ArgumentException(string.Format("{0}-{1}", Properties.Resources.INVALID_VALUE.ToString(), EValidationRules.INVALID_VALUE.GetDescription()));

                if (!movimentAccountRequest.MovimentType.Equals("C") && !movimentAccountRequest.MovimentType.Equals("D"))
                    throw new ArgumentException(string.Format("{0}-{1}", Properties.Resources.INVALID_TYPE.ToString(), EValidationRules.INVALID_TYPE.GetDescription()));

                var createResponse = await _mediator.Send(new CreateMovimentRequest
                {
                    CheckingAccount = account.Id,
                    MovimentType = movimentAccountRequest.MovimentType,
                    Value = movimentAccountRequest.Value,
                    RequestId = movimentAccountRequest.Id
                });

                return createResponse.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AccountBalanceResponse> GetAccountBalanceAsync(int accountNumber)
        {
            var account = await _mediator.Send(new FindAccountByNumberRequest { Number = accountNumber }) ?? throw new ArgumentException(string.Format("{0}-{1}", Properties.Resources.INVALID_BALANCE_ACCOUNT.ToString(), EValidationRules.INVALID_ACCOUNT.GetDescription()));

            if (!account.Active)
                throw new ArgumentException(string.Format("{0}-{1}", Properties.Resources.INACTIVE_BALANCE_ACCOUNT.ToString(), EValidationRules.INACTIVE_ACCOUNT.GetDescription()));

            var accountBalance = await _mediator.Send(new FindAccountBalanceByIdRequest { Id = account.Id });

            return new AccountBalanceResponse
            {
                AccountNumber = account.Number,
                ClientName = account.Name,
                RequestDate = DateTime.Now,
                AccountBalance = accountBalance.AccountBalance
            };
        }
    }
}
