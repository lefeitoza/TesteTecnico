using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CreateMovimentRequest: IRequest<CreateMovimentResponse>
    {        
        public string CheckingAccount { get; set; }        
        public string MovimentType { get; set; }
        public double Value { get; set; }

        public string RequestId { get; set; }
    }
}
