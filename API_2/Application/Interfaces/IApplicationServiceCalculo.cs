using Core.Validation;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationServiceCalculo
    {
        Task<decimal> GetCalculoAsync(decimal valorInicial, int tempo);
        INotificacao RetornarNotificacao();
    }
}
