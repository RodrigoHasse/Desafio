using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class JuroController : Controller
    {
        private readonly IApplicationServiceJuro _servicoAplicacao;

        public JuroController(IApplicationServiceJuro servicoAplicacao)
        {
            _servicoAplicacao = servicoAplicacao;   
        }

        [HttpGet("taxaJuros")]
        //[ProducesResponseType(typeof(Calculo), 200)]
        public IActionResult taxaJuro()
        {
            var calculo = _servicoAplicacao.GetJuro();
            if (calculo == null)
            {
                return BadRequest("Juro não encontrado");
            }
            return Ok(calculo);
        }
    }
}
