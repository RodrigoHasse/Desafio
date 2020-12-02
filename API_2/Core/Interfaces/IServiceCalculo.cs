using Core.Models.Calculo;
using Core.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IServiceCalculo
    {
        decimal GetCalculo(decimal valorInicial, int tempo);
        void ValidarAsync(Calculo calculo);
        INotificacao RetornarNotificacao();
    }
}
