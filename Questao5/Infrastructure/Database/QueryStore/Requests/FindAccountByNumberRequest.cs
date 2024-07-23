using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class FindAccountByNumberRequest :IRequest<FindAccountByNumberResponse>
    {
        public int Number { get; set; }
    }
}
