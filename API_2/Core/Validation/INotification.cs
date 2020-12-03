using System.Collections.Generic;

namespace Core.Validation
{
    public interface INotificacao
    {
        void Adicionar(string mensagem);
        bool IsValid();
        List<string> RetornarErros();
    }
}