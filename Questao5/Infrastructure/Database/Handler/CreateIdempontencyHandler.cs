using MediatR;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Database.CommandStore.Requests;

namespace Questao5.Infrastructure.Database.Handler
{
    public class CreateIdempontencyHandler : IRequestHandler<CreateIdempontencyRequest, string>
    {
        private readonly IIdempontencyRepository _idempontencyRepository;

        public CreateIdempontencyHandler(IIdempontencyRepository idempontencyRepository)
        {
            _idempontencyRepository = idempontencyRepository;
        }

        public void Handle(CreateIdempontencyRequest createIdempontencyRequest)
        {
            _idempontencyRepository.Create(new Domain.Entities.Account.Idempontency
            {
                RequestId = createIdempontencyRequest.RequestId,
                Result = createIdempontencyRequest.Result
            });
        }

        public Task<string> Handle(CreateIdempontencyRequest request, CancellationToken cancellationToken)
        {
            _idempontencyRepository.Create(new Domain.Entities.Account.Idempontency
            {
                RequestId = request.RequestId,
                Result = request.Result
            });

            return Task.FromResult("true");
        }
    }
}
