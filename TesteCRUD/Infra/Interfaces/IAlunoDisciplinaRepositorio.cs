using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IAlunoDisciplinaRepositorio : IBaseRepositorio<AlunoDisciplina>
    {
        Task<List<AlunoDisciplina>> ListaDisciplinas(int codigoAluno);
        Task<List<AlunoDisciplina>> ListaAlunoPorStatus(string status);
        Task<AlunoDisciplina> ListaPorAlunoDisciplina(int codigoAluno, int codigoDisciplina);
    }
}
