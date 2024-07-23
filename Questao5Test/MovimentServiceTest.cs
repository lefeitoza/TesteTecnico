using MediatR;
using Moq;
using NUnit.Framework;
using Questao5.Domain.Entities.Interfaces;
using Questao5.Infrastructure.Database.QueryStore;
using Questao5.Service;
using Xunit;

namespace Questao5Test
{
    public class MovimentServiceTest
    {

        Mock<MovimentService> mockMovimentService;
        Mock<IIdempontencyRepository> mockIdempontecyRepository;
        Mock<IMediator> mockMediator;

        [SetUp]
        public void Setup()
        {
            mockMediator = new Mock<IMediator>();
            mockIdempontecyRepository = new Mock<IIdempontencyRepository>();
            mockMovimentService = new Mock<MovimentService>(mockMediator.Object);
        }

        [Fact]
        [Description("Espera erro ao gerar movimento")]
        public void ErroAoInserirDadosDeMovimento()
        {
            var mediator = new Mock<IMediator>();

            QueryIdempontencyCommand command = 
                new QueryIdempontencyCommand(mockIdempontecyRepository.Object);


            mockMediator.Setup(x => x.Send(It.IsAny<command>())).Returns(null);

            mockMovimentService.Object.
            Assert.Pass();
        }
    }
}