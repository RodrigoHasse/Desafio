using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IServiceTaxaJuro
    {
        [Get("/taxajuros")]
        Task<decimal> RetornarTaxaJuros();
    }
}
