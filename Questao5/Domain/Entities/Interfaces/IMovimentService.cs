using Questao5.Domain.Entities.Request;
using Questao5.Domain.Entities.Response;

namespace Questao5.Domain.Entities.Interfaces
{
    public interface IMovimentService
    {
        Task<string> Create(AccountMovimentRequest movimentAccountRequest);

        Task<AccountBalanceResponse> GetAccountBalanceAsync(int accountNumber);
    }
}
