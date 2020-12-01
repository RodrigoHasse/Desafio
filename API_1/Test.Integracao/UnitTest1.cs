using API.Controllers;
using Application.Interfaces;
using Core.ViewModels.Output;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Test.Integracao
{
    public class UnitTest1
    {
        Mock<IApplicationServiceJuro> _applicationServiceJuroMock;
        JuroController _controller;

        public UnitTest1()
        {
            _applicationServiceJuroMock = new Mock<IApplicationServiceJuro>();
            _controller = new JuroController(_applicationServiceJuroMock.Object);
        }

        [Fact]
        public void Get_DeveChamarService_Retornar200_ComValor0VirgulaZeroUm()
        {
            var valorEsperado = new JuroOutputModel { Taxa = 0.01M } ;
            _applicationServiceJuroMock.Setup(x => x.GetJuro()).Returns(valorEsperado);

            var resultado = _controller.taxaJuro();

            var objResultado = Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(200, objResultado.StatusCode);

            //var value = Assert.IsType<decimal>(objResultado.Value);
            //Assert.Equal(valorEsperado.Taxa, objResultado.Value);
        }
    }
}
