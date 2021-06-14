using Fullbar.Teste.Application.Notificacoes;
using System.Collections.Generic;

namespace Fullbar.Teste.Application.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}