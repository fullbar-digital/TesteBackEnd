using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppAlunos.Api.Models.Request;
using AppAlunos.Business.Models;
using AppAlunos.Business.Models.Response;

namespace AppAlunos.Business.Intefaces
{
    public interface IAlunoService : IDisposable
    {
        Task<Aluno> Adicionar(AlunoRequest aluno);
        Task<bool> Atualizar(Aluno aluno);
        Task<bool> Remover(Guid id);
        IEnumerable<AlunoResponse> ListarAlunos();
        IEnumerable<AlunoResponse> ListarPorFiltro(string filtros, string valores);

    }
}