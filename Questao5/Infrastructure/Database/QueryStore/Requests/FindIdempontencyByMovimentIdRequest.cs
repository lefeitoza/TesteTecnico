
using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class FindIdempontencyByMovimentIdRequest :IRequest<FindIdempontencyByMovimentIdResponse>
    {
        public string Id { get; set; }
    }
}
