using API.Controllers;
using Application.Interfaces;
using Core.ViewModels.Output;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Test.Integracao
{
    public class TaxaJuroIntegracaoTest
    {
        Mock<IApplicationServiceJuro> _applicationServiceJuroMock;
        JuroController _controller;

        public TaxaJuroIntegracaoTest()
        {
            _applicationServiceJuroMock = new Mock<IApplicationServiceJuro>();
            _controller = new JuroController(_applicationServiceJuroMock.Object);
        }

        [Fact]
        public void GetTaxaJuro_SemParametros_DeveRetornar200()
        {
            var valorEsperado = new JuroOutputModel { Taxa = 0.01M } ;
            _applicationServiceJuroMock.Setup(x => x.GetJuro()).Returns(valorEsperado);

            var resultado = _controller.taxaJuro();

            var response = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(200, response.StatusCode);
        }
    }
}
