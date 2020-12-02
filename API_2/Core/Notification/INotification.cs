using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Notification
{
    public interface INotificacao
    {
        void Adicionar(string mensagem);
        bool IsValid();
        List<string> RetornarErros();
    }
}
