using API.Controllers;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Integracao
{
    public class Calculo_IntegracaoTest
    {
        Mock<IApplicationServiceCalculo> _applicationServiceJuroMock;
        CalculoController _controller;

        public Calculo_IntegracaoTest()
        {
            _applicationServiceJuroMock = new Mock<IApplicationServiceCalculo>();
            _controller = new CalculoController(_applicationServiceJuroMock.Object);
        }

        [Theory]
        [InlineData(100, 5)]
        public async Task calculajuros_ValoresCalculoInformadoCorretamente_RetornaSucessoTaxaJuros(decimal valorInicial, int tempo)
        {
            var Esperado = 150.10M;
            _applicationServiceJuroMock.Setup(x => x.GetCalculoAsync(valorInicial, tempo)).Returns(Task.FromResult(Esperado));
            _applicationServiceJuroMock.Setup(x => x.RetornarNotificacao().IsValid()).Returns(true);

            var resultado = await _controller.calculajurosAsync(valorInicial, tempo);

            var response = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(200, response.StatusCode);

            var value = Assert.IsType<decimal>(response.Value);
            Assert.Equal(Esperado, response.Value);
        }

        [Theory]
        [InlineData(100, -5)]
        [InlineData(-100, 5)]
        [InlineData(-100, -5)]
        public async Task calculajuros_ValoresCalculoNegativos_RetornaBadRequest(decimal valorInicial, int tempo)
        {            
            _applicationServiceJuroMock.Setup(x => x.GetCalculoAsync(valorInicial, tempo)).Returns(Task.FromResult(0.00M));
            _applicationServiceJuroMock.Setup(x => x.RetornarNotificacao().IsValid()).Returns(false);

            var resultado = await _controller.calculajurosAsync(valorInicial, tempo);

            var response = Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal(400, response.StatusCode);
        }

        [Theory]
        [InlineData(100, 0)]
        [InlineData(0, 5)]
        [InlineData(0, 0)]
        public async Task calculajuros_ValoresCalculoZerados_RetornaBadRequest(decimal valorInicial, int tempo)
        {
            _applicationServiceJuroMock.Setup(x => x.GetCalculoAsync(valorInicial, tempo)).Returns(Task.FromResult(0.00M));
            _applicationServiceJuroMock.Setup(x => x.RetornarNotificacao().IsValid()).Returns(false);

            var resultado = await _controller.calculajurosAsync(valorInicial, tempo);

            var response = Assert.IsType<BadRequestObjectResult>(resultado);
            Assert.Equal(400, response.StatusCode);
        }
    }
}
