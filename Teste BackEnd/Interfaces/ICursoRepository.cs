using Teste_BackEnd.Models;

namespace Teste_BackEnd.Interfaces
{
    public interface ICursoRepository
    {
        #region POST
        void Add(Curso obj);
        #endregion

        #region GET
        Curso GetByNome(string nome);
        #endregion

    }
}
