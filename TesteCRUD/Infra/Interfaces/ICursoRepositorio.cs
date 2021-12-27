using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ICursoRepositorio : IBaseRepositorio<Curso>
    {
        Task<List<Curso>> ListaCursoPorNome(string nome);
    }
}
