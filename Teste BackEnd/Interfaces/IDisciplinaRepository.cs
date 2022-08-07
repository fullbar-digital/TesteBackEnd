using Teste_BackEnd.Models;

namespace Teste_BackEnd.Interfaces
{
    public interface IDisciplinaRepository
    {
        #region POST
        void Add(Disciplina obj);
        #endregion

        #region GET
        Disciplina GetByNome(string nome, int cursoId);
        #endregion

    }
}
