using System.Collections.Generic;
using AppAlunos.Business.Notificacoes;

namespace AppAlunos.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}