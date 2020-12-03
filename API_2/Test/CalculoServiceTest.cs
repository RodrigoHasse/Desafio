using Core.Helpers;
using Core.Interfaces;
using Core.Services;
using Core.Validation;
using DecimalMath;
using infra.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test.Unit
{
    public class CalculoServiceTest
    {
        readonly Mock<INotificacao> _notificacaoMock;
        readonly Mock<IRepositoryTaxaJuros> _repositorioCalculoMock;
        readonly ServiceCalculo _serviceCalculo; 
        public CalculoServiceTest()
        {
            _notificacaoMock = new Mock<INotificacao>();
            _repositorioCalculoMock = new Mock<IRepositoryTaxaJuros>();
            _serviceCalculo = new ServiceCalculo(_notificacaoMock.Object, _repositorioCalculoMock.Object);
        }
        
        [Theory]
        [InlineData(100, 0.01, 5)]
        public void Deve_Retornar_Um_Decimal(decimal valorInicial, decimal juro, int tempo)
        {            
            _repositorioCalculoMock.Setup(_ => _.RetornarTaxaJurosAsync()).Returns(Task.FromResult(juro));

            var result = _serviceCalculo.GetCalculo(valorInicial, tempo).Result;

            _repositorioCalculoMock.Verify(_ => _.RetornarTaxaJurosAsync(), Times.Once);

            Assert.IsType<decimal>(result);
        }

        //[Theory]
        //[InlineData(100, 0.01, 5)]
        //public async Task Calcular_Retorno_Com_Valores_Validos(decimal valorInicial, decimal juro, int tempo)
        //{
        //    var potencia = DecimalEx.Pow(1 + juro, tempo);
        //    var resultado = DecimalHelpers.Truncate(valorInicial * potencia, 2);
        //    _repositorioCalculoMock.Setup(_ => _.RetornarTaxaJurosAsync()).Returns(Task.FromResult(juro));

        //    var result = _serviceCalculo.GetCalculo(valorInicial, tempo).Result;

        //    Assert.Equal(resultado, result);
        //}

        //[Theory]
        //[InlineData(-100, 0.01, 5, "")]
        //[InlineData(100, -0.01, 5, "")]
        //[InlineData(100, 0.01, -5, "")]
        //public void Deve_Retornar_Erro_Com_Valores_Negativos(decimal valorInicial, decimal juro, int tempo, string mensagemErro)
        //{
        //    var esperado = "Não foi possivel realizar o calculo de Juros, os valores devem ser maiores que zero.";
        //    _repositorioCalculoMock.Setup(_ => _.RetornarTaxaJurosAsync()).Returns(Task.FromResult(juro));

        //    Task Erro() => Task.Run(() => _serviceCalculo.GetCalculo(valorInicial, tempo));

        //    //var exception = await Record.ExceptionAsync(Erro);

        //    _repositorioCalculoMock.Verify(_ => _.RetornarTaxaJurosAsync(), Times.Once);

        //    //Assert.NotNull(exception);
        //    //Assert.IsType<ArgumentException>(exception);
        //    Assert.Equal(esperado, "");
        //}
    }
}
