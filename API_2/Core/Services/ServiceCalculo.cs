using Core.Interfaces;
using Core.Models.Calculo;
using Core.Notification;

namespace Core.Services
{
    public class ServiceCalculo : IServiceCalculo
    {
        protected INotificacao Notificacao { get { return _notificacao; } }
        protected INotificacao _notificacao;

        public ServiceCalculo(INotificacao notificacao)
        {
            _notificacao = notificacao;
        }
        public void ValidarAsync(Calculo calculo)
        {
            var validacao = new CalculoValidation(calculo);

            foreach (var notificacao in validacao.Contract.Notifications)
                _notificacao.Adicionar(notificacao.Message);
        }

        public decimal GetCalculo(decimal valorInicial, int tempo)
        {            
            var calculo = Calculo.Criar(0.01M, valorInicial, tempo);
            this.ValidarAsync(calculo);

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
