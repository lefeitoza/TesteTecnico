using Dapper;
using Questao5.Domain.Entities.Account;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbSession _db;

        public AccountRepository(DbSession db)
        {
            _db = db;
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            using var con = _db.Connection;            
            const string sql = "SELECT idcontacorrente as Id, numero as Number, nome as Name, ativo as Active FROM contacorrente WHERE numero = @number";
            return con.QueryFirstOrDefault<Account>(sql, param: new { number = accountNumber });
        }
    }
}
