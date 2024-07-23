using MediatR;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.Handler
{
    public class FindAccountBalanceByIdHandler : IRequestHandler<FindAccountBalanceByIdRequest, FindAccountBalanceByIdResponse>
    {
        private readonly IMovimentRepository _movimentRepository;

        public FindAccountBalanceByIdHandler(IMovimentRepository movimentRepository)
        {
            _movimentRepository = movimentRepository;
        }

        public Task<FindAccountBalanceByIdResponse> Handle(FindAccountBalanceByIdRequest request, 
                                                           CancellationToken cancellationToken)
        {
            var accountBalance = _movimentRepository.GetAccountBalanceById(request.Id);

            var response = new FindAccountBalanceByIdResponse
            {
                AccountBalance = accountBalance
            };

            return Task.FromResult(response);            
        }
    }
}
