using MediatR;
using Questao5.Domain.Entities.Account;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.Handler
{
    public class CreateMovimentHandler : IRequestHandler<CreateMovimentRequest, CreateMovimentResponse>
    {
        private readonly IMovimentRepository _movimentRepository;
        private readonly IIdempontencyRepository _idempontencyRepository;

        public CreateMovimentHandler(IMovimentRepository movimentRepository, 
                                     IIdempontencyRepository idempontencyRepository)
        {
            _movimentRepository = movimentRepository;
            _idempontencyRepository = idempontencyRepository;
        }

        public Task<CreateMovimentResponse> Handle(CreateMovimentRequest request, CancellationToken cancellationToken)
        {
            var moviment = new Moviment
            {
                IdCheckingAccount = request.CheckingAccount,
                Date = DateTime.Now,
                MovimentType = request.MovimentType,
                Value = request.Value
            };

            _movimentRepository.Create(moviment);

            var idempontency = new Idempontency
            {
                RequestId = request.RequestId,
                Result = moviment.Id
            };

            _idempontencyRepository.Create(idempontency);

            var result = new CreateMovimentResponse
            {
                Id = moviment.Id
            };

            return Task.FromResult(result);
        }
    }
}
