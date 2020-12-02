using Core.Services;
using System;
using Xunit;

namespace Test.Unit
{
    public class CalculoServiceTest
    {
        [Theory]
        [InlineData(100, 0.01, 5)]
        public void GetCalculo(decimal valorInicial, decimal juro, int tempo)
        {
            //decimal retornoEsperado = DecimalMath.Pow((1 + juro), tempo);
            //valorInicial *
            //ServiceCalculo servCalculo = new ServiceCalculo();

            //var retorno = servCalculo.GetCalculo();

            //Assert.Equal((decimal)retornoEsperado, retorno.Resultado);
        }
    }
}
