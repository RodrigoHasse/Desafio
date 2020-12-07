using Core.Interfaces;
using Core.Services;
using Core.Validation;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit
{
    public class CalculoServiceTest
    {
        readonly Mock<INotificacao> _notificacaoMock;
        readonly Mock<IServiceTaxaJuro> _serviceTaxaJurMock;
        readonly ServiceCalculo _serviceCalculo;
        public CalculoServiceTest()
        {
            _notificacaoMock = new Mock<INotificacao>();
            _serviceTaxaJurMock = new Mock<IServiceTaxaJuro>();
            _serviceCalculo = new ServiceCalculo(_notificacaoMock.Object, _serviceTaxaJurMock.Object);
        }

        [Theory]
        [InlineData(100, 0.01, 5, 105.10)]
        public async Task CalculoService_ComValoresValidos_DeveRetornarUmDecimalIgualAoResultadoEsperado(decimal valorInicial, decimal juro, int tempo, decimal resultadoEsperado)
        {
            var Esperado = resultadoEsperado;

            _serviceTaxaJurMock.Setup(x => x.RetornarTaxaJuros()).Returns(Task.FromResult(juro));
            _notificacaoMock.Setup(x => x.IsValid()).Returns(true);

            var result = await _serviceCalculo.GetCalculoAsync(valorInicial, tempo);

            Assert.IsType<decimal>(result);

            Assert.Equal(Esperado, result);
        }

        [Theory]
        [InlineData(-100, 0.01, 5)]
        [InlineData(100, -0.01, 5)]
        [InlineData(100, 0.01, -5)]
        public async Task CalculoService_ComValoresNegativos_DeveRetornarZero(decimal valorInicial, decimal juro, int tempo)
        {            
            _serviceTaxaJurMock.Setup(x => x.RetornarTaxaJuros()).Returns(Task.FromResult(juro));

            var result = await _serviceCalculo.GetCalculoAsync(valorInicial, tempo);

            _serviceTaxaJurMock.Verify(x => x.RetornarTaxaJuros(), Times.Once);

            Assert.Equal(0, result);
        }
    }
}