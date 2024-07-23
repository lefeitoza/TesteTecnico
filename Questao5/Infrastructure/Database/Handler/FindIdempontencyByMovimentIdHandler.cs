using MediatR;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.Handler
{
    public class FindIdempontencyByMovimentIdHandler: IRequestHandler<FindIdempontencyByMovimentIdRequest, FindIdempontencyByMovimentIdResponse>
    {
        private readonly IIdempontencyRepository _idempontencyRepository;

        public FindIdempontencyByMovimentIdHandler(IIdempontencyRepository idempontencyRepository)
        {
            _idempontencyRepository = idempontencyRepository;
        }
        public Task<FindIdempontencyByMovimentIdResponse> Handle(FindIdempontencyByMovimentIdRequest request, CancellationToken cancellationToken)
        {
            var idempontency = _idempontencyRepository.GetByRequestId(request.Id);            

            var response =  new FindIdempontencyByMovimentIdResponse
            {
                Result = idempontency?.Result
            };

            return Task.FromResult(response);
        }
    }
}
