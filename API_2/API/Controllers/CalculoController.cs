﻿using Application.Interfaces;
using Core.Models.Calculo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CalculoController : Controller
    {
        private readonly IApplicationServiceCalculo _servicoAplicacao;

        public CalculoController(IApplicationServiceCalculo servicoAplicacao)
        {
            _servicoAplicacao = servicoAplicacao;
        }

        [HttpGet("calculajuros")]
        //[ProducesResponseType(typeof(Calculo), 200)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> calculajurosAsync([FromQuery][BindRequired] decimal valorInicial, [FromQuery][BindRequired] int tempo)
        {
            var calculo = _servicoAplicacao.GetCalculo(valorInicial, tempo);

            if (!_servicoAplicacao.RetornarNotificacao().IsValid())
                return BadRequest(error: _servicoAplicacao.RetornarNotificacao().RetornarErros());

            return Ok(calculo);
        }
    }
}