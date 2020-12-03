using Application.Interfaces;
using Core.Interfaces;
using Core.Validation;
using System.Threading.Tasks;

namespace Aplicacao.Services
{
    public class AplicationServiceCalculo : IApplicationServiceCalculo
    {
        private readonly IServiceCalculo _servico;

        public AplicationServiceCalculo(IServiceCalculo servico)
        {
            _servico = servico;
        }
        public async Task<decimal> GetCalculo(decimal valorInicial, int tempo)
        {   
            return await _servico.GetCalculo(valorInicial, tempo);
        }

        public INotificacao RetornarNotificacao()
        {
            return _servico.RetornarNotificacao();
        }
    }
}
