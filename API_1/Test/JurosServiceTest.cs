using Core.Services;
using System;
using Xunit;

namespace Test.Unit
{
    public class JuroServiceTest
    {
        [Theory]
        [InlineData(0.01)]
        public void GetJuro_SemParametros_DeveRetornar1_01(decimal taxa)
        {
            ServicoJuro servJuro = new ServicoJuro();

            var retorno = servJuro.GetJuro();

            Assert.Equal(taxa, retorno.Taxa);
        }
    }
}
