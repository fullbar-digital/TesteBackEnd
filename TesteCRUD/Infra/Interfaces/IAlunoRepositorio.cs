using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IAlunoRepositorio : IBaseRepositorio<Aluno>
    {
        Task<List<Aluno>> ListaAlunoPorNome(string nome);
        Task<Aluno> ListaAlunoPorRA(string ra);
        Task<List<Aluno>> ListaAlunoPorCurso(int codigo);
    }
}
