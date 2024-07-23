using Questao5.Domain.Entities.Account;

namespace Questao5.Domain.Entities.Interfaces
{
    public interface IIdempontencyRepository
    {
        void Create(Idempontency idempontency);
        Idempontency GetByRequestId(string requestId);
    }
}
