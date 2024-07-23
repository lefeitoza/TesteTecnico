
namespace Questao5.Domain.Entities.Interfaces
{
    public interface IAccountRepository
    {
        Account.Account GetAccountByNumber(int accountNumber);
        
    }
}
