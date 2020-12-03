using Core.Validation;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceCalculo
    {
        Task<decimal> GetCalculo(decimal valorInicial, int tempo);
        INotificacao RetornarNotificacao();
    }
}
