using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult taxaJuro()
        {
            try
            {
                return Ok(_servicoAplicacao.GetJuro().Taxa);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
        }
    }
}