using System.Collections.Generic;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Interfaces
{
    public interface IAlunoRepository
    {
        #region POST
        void Add(Aluno obj);
        #endregion

        #region PUT
        Aluno Update(int id, Aluno obj);
        #endregion

        #region DELETE
        void Delete(int id);
        #endregion

        #region GET
        Aluno GetById(int id);
        Aluno GetByNome(string nome);
        IList<Aluno> GetByCurso(int cursoId);
        Aluno GetByRA(string ra);
        IList<Aluno> GetByStatus(string status);
        IList<Aluno> GetAll();
        #endregion
    }
}
