using Core.Models.Calculo;
using Core.Validation;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IServiceCalculo
    {
        Task<decimal> GetCalculo(decimal valorInicial, int tempo);
        Task ValidarAsync(Calculo calculo);
        INotificacao RetornarNotificacao();
    }
}
