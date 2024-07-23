using MediatR;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CreateIdempontencyRequest : IRequest<string>
    {        
        public string RequestId { get; set; }
        public string Result { get; set; }
    }        
}
