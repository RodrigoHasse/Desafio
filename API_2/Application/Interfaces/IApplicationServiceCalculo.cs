using Core.Notification;

namespace Application.Interfaces
{
    public interface IApplicationServiceCalculo
    {
        decimal GetCalculo(decimal valorInicial, int tempo);
        INotificacao RetornarNotificacao();
    }
}
