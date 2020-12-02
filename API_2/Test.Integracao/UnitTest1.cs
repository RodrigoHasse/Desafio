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
        //Mock<IApplicationServiceCalculo> _applicationServiceJuroMock;
        //CalculoController _controller;

        //public UnitTest1()
        //{
        //    _applicationServiceJuroMock = new Mock<IApplicationServiceCalculo>();
        //    _controller = new CalculoController(_applicationServiceJuroMock.Object);
        //}

        //[Fact]
        //public void Get_DeveChamarService_Retornar200_ComValor0VirgulaZeroUm()
        //{
        //    var valorEsperado = new CalculoOutputModel { Resultado = 0.01M } ;
        //    _applicationServiceJuroMock.Setup(x => x.GetCalculo()).Returns(valorEsperado);

        //    var resultado = _controller.taxaJuro();

        //    var response = Assert.IsType<OkObjectResult>(resultado);
        //    Assert.Equal(200, response.StatusCode);

        //    //var value = Assert.IsType<decimal>(objResultado.Value);
        //    //Assert.Equal(valorEsperado.Taxa, objResultado.Value);
        //}
    }
}
