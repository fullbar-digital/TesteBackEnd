using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppAlunos.Business.Models;

namespace AppAlunos.Business.Intefaces
{
    public interface ICursoService : IDisposable
    {
        Task<bool> Adicionar(Curso curso, IEnumerable<string> disciplinas);
    }
}