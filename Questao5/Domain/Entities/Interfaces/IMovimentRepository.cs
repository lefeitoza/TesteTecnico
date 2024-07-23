using Questao5.Domain.Entities.Account;

namespace Questao5.Domain.Entities.Interfaces
{
    public interface IMovimentRepository
    {
        void Create(Moviment moviment);

        double GetAccountBalanceById(string id);
    }
}
