using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        public List<Aluno> ListarAlunos();

        public Task<List<Aluno>> FiltrarAlunos(string filtrar, string parametro);
    }
}