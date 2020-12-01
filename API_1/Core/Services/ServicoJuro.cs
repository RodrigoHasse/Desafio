using Core.Interfaces;
using Core.Models.Juro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServicoJuro : IServicoJuro
    {
        public Juro GetJuro()
        {
            var calculo = Juro.Criar(0.01M);
            return calculo;
        }
    }
}
