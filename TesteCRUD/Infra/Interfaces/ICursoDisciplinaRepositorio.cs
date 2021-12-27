using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ICursoDisciplinaRepositorio : IBaseRepositorio<CursoDisciplina>
    {
        Task<CursoDisciplina> ListaPorCursoDisciplina(CursoDisciplina cursoDisciplina);
        Task<List<CursoDisciplina>> ListaPorCurso(int cursoCodigo);
        Task<List<CursoDisciplina>> ListaPorDisciplina(int disciplinaCodigo);
    }
}
