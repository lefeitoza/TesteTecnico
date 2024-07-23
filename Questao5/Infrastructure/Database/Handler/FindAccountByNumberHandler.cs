using MediatR;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.Handler
{
    public class FindAccountByNumberHandler : IRequestHandler<FindAccountByNumberRequest, FindAccountByNumberResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public FindAccountByNumberHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<FindAccountByNumberResponse> Handle(FindAccountByNumberRequest request, CancellationToken cancellationToken)
        {
            var account = _accountRepository.GetAccountByNumber(request.Number);

            var response = new FindAccountByNumberResponse
            {
                Id = account?.Id,
                Active = account.Active,
                Name = account?.Name,
                Number = account.Number,
            };

            return Task.FromResult(response);
        }
    }
}
