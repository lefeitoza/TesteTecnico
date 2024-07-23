using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class FindAccountBalanceByIdRequest : IRequest<FindAccountBalanceByIdResponse>
    {
        public string Id { get; set; }
    }
}
