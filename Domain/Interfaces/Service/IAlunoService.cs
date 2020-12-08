using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service.Aluno.Aluno
{
    public interface IAlunoService
    {
        List<Entities.Aluno> ListarAlunos();

        Task<List<Entities.Aluno>> FiltrarAlunos(string filtrar, string parametro);

        Task<AlunoDto> Get(Guid id);

        Task<Entities.Aluno> Post(AlunoDtoCreate user);

        Task<Entities.Aluno> Put(AlunoDtoUpdate user);

        Task<bool> Delete(Guid id);
    }
}