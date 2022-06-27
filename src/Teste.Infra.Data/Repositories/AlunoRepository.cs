using Microsoft.EntityFrameworkCore;
using Teste.Domain.Alunos.Dto;
using Teste.Domain.Alunos.Entities;
using Teste.Domain.Alunos.Repositories;
using Teste.Infra.Data.Contexts;
using Teste.Infra.Data.Repositories.Common;

namespace Teste.Infra.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public readonly TesteContexto _dbContexto;

        public AlunoRepository(TesteContexto dbContexto) : base(dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public void Alterar(Aluno entity)
        {
            var aluno = _dbContexto.Set<Aluno>().First(x => x.Id == entity.Id);            

            if (aluno != null)
            {
                aluno.Nome = entity.Nome;
                aluno.RA = entity.RA;
                aluno.Periodo = entity.Periodo;
                aluno.CursoId = entity.CursoId;
                aluno.Foto = entity.Foto;               

                DbSet.Update(aluno);
                return;
            }

            throw new ArgumentException($"Erro ao alterar Aluno: Não encontrado! ");
        }

        public async Task<List<Aluno>> GetByConditionAsync(FilterAlunoDto filterAluno)
        {
            var result = (from al in DbSet
                          where (al.Nome.ToUpper().Contains(filterAluno.Nome.ToUpper()) || string.IsNullOrEmpty(filterAluno.Nome)) &&
                                (al.RA.ToUpper().Contains(filterAluno.RegistroAcademico.ToUpper()) || string.IsNullOrEmpty(filterAluno.RegistroAcademico)) &&
                                (al.Curso.Nome.ToUpper().Contains(filterAluno.Curso.ToUpper()) || string.IsNullOrEmpty(filterAluno.Curso)) &&
                                (al.Status.ToUpper().Contains(filterAluno.Status.ToUpper()) || string.IsNullOrEmpty(filterAluno.Status))
                          select new Aluno
                          {
                              Id = al.Id,
                              Nome = al.Nome,
                              RA = al.RA,
                              Periodo = al.Periodo,
                              Foto = al.Foto,
                              Curso = al.Curso,
                              CursoId = al.CursoId,
                              Status = string.Join(" | ", al.Curso.Disciplinas.Select(x => (x.NotaMinimaAprovacao > 7.0m ? $"Aprovado(a) em : {x.Nome}" : $"Reprovado(a) em :{x.Nome}")))
                          }).AsNoTracking();

            return await result.ToListAsync();            
        }

        public Guid Inserir(Aluno entity)
        {
            return Add(entity);
        }

        public Task<List<Aluno>> ObterTodos()
        {
            var result = (from al in DbSet
                          select new Aluno
                          {
                              Id = al.Id,
                              Nome = al.Nome,
                              RA = al.RA,
                              Periodo = al.Periodo,
                              Foto = al.Foto,
                              Curso = al.Curso,
                              CursoId = al.CursoId,
                              Status = string.Join(" | ", al.Curso.Disciplinas.Select(x => (x.NotaMinimaAprovacao > 7.0m ? $"Aprovado(a) em : {x.Nome}" : $"Reprovado(a) em :{x.Nome}")))
                          }).AsNoTracking();

            return result.ToListAsync();
        }

        public void Remover(Guid id)
        {
            Remove(id);
        }
    }
}
