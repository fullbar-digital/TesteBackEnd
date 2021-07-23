using System;
using System.Threading.Tasks;
using AppAlunos.Business.Models;

namespace AppAlunos.Business.Intefaces
{
    public interface IDisciplinaService : IDisposable
    {
        Task<bool> Adicionar(Disciplina disciplina);

    }
}