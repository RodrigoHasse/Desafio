using Core.Interfaces;
using Core.Models.Calculo;
using Core.Validation;
using infra.Repositories;
using System;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceCalculo : IServiceCalculo
    {
        protected INotificacao Notificacao { get { return _notificacao; } }
        protected INotificacao _notificacao;
        protected IRepositoryTaxaJuros _repositoryTaxaJuros;

        public ServiceCalculo(INotificacao notificacao, IRepositoryTaxaJuros repositoryTaxaJuros)
        {
            _notificacao = notificacao;
            _repositoryTaxaJuros = repositoryTaxaJuros;
        }
        public async Task ValidarAsync(Calculo calculo)
        {
            var validacao = new CalculoValidation(calculo);

            foreach (var notificacao in validacao.Contract.Notifications)
                _notificacao.Adicionar(notificacao.Message);
        }

        public async Task<decimal> GetCalculo(decimal valorInicial, int tempo)
        {
            decimal taxaJuro = 0;
            try
            {
                taxaJuro = await _repositoryTaxaJuros.RetornarTaxaJurosAsync();
            }
            catch (Exception ex) 
            {
                _notificacao.Adicionar("Erro ao buscar taxa de juros.");
                return 0;
            }       

            var calculo = Calculo.Criar(taxaJuro, valorInicial, tempo);

            await ValidarAsync(calculo);

            if (_notificacao.IsValid())
            {
                return calculo.Calcular();
            }
            return 0;
        }

        public INotificacao RetornarNotificacao()
        {
            return Notificacao;
        }
    }
}