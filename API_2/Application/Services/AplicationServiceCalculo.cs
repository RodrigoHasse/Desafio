using Application.Interfaces;
using AutoMapper;
using Core.Interfaces;
using Core.Models.Calculo;
using Core.Notification;
using Core.ViewModels.Output;

namespace Aplicacao.Services
{
    public class AplicationServiceCalculo : IApplicationServiceCalculo
    {
        private readonly IServiceCalculo _servico;
        private readonly IMapper _mapper;

        public AplicationServiceCalculo(IServiceCalculo servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }
        public decimal GetCalculo(decimal valorInicial, int tempo)
        {   
            return _servico.GetCalculo(valorInicial, tempo);
        }

        public INotificacao RetornarNotificacao()
        {
            return _servico.RetornarNotificacao();
        }
    }
}
