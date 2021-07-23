using AppAlunos.Business.Models;

namespace AppAlunos.Business.Intefaces
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Curso BuscarPorNome(string nome);
    }
}