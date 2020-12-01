using Application.Interfaces;
using AutoMapper;
using Core.Interfaces;
using Core.Models.Juro;
using Core.ViewModels.Output;

namespace Aplicacao.Services
{
    public class AplicationServiceCalculo : IApplicationServiceJuro
    {
        private readonly IServicoJuro _servico;
        private readonly IMapper _mapper;

        public AplicationServiceCalculo(IServicoJuro servico, IMapper mapper)
        {
            _servico = servico;
            _mapper = mapper;
        }
        public JuroOutputModel GetJuro()
        {
            var retorno = _mapper.Map<Juro, JuroOutputModel>(_servico.GetJuro()) ;
            
            return retorno;
        }
    }
}
