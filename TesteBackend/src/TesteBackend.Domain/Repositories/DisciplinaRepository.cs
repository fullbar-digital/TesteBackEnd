using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TesteBackend.Domain.Exceptions;
using TesteBackend.Domain.Models;

namespace TesteBackend.Domain.Repositories
{
    public interface IDisciplinaRepository
    {
        public Disciplina Add(Disciplina disciplina);
        public Disciplina Get(int disciplinaId);
        public void Delete(int disciplinaId);
    }

    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(DbBackendContext context) : base(context)
        {
        }

        /// <summary>
        /// Adicionar disciplina
        /// </summary>
        /// <param name="disciplina">Disciplina para cadastro</param>
        /// <returns>Retorna disciplina cadastrada</returns>
        /// <exception cref="OperationCanceledException">Não é possível cadastrar disciplina para cursos com alunos matriculados</exception>
        public Disciplina Add(Disciplina disciplina)
        {
            var qtdMatriculas = this.context
                                      .Alunos
                                      .Where(a => a.CursoId == disciplina.Curso.Id)
                                      .Count();

            if (qtdMatriculas > 0)
            {
                var msg = $"Operação Inválida: Não é permitido cadastrar disciplina em curso com alunos matriculados. ";
                msg += "É necessário remover os alunos para cadastrar uma nova disciplina";
                throw new OperationCanceledException(msg);
            }

            this.dbSets.Add(disciplina);
            this.Save();

            return disciplina;
        }

        /// <summary>
        /// Consulta disciplina
        /// </summary>
        /// <param name="disciplinaId">Identificador da disciplina</param>
        /// <returns>Retorna disciplina</returns>
        public Disciplina Get(int disciplinaId)
        {
            var disciplina = this.dbSets
                                .Include(c => c.Curso)
                                .Include(m => m.DisciplinasMatricula)
                                .Where(d => d.Id == disciplinaId)
                                .FirstOrDefault();

            return disciplina;
        }

        /// <summary>
        /// Excluir disciplina
        /// </summary>
        /// <param name="disciplinaId">Identificador da disciplina</param>
        public void Delete(int disciplinaId)
        {
            Disciplina disciplinaDb = this.dbSets
                                          .Include(d => d.DisciplinasMatricula)
                                          .Where(d => d.Id == disciplinaId)
                                          .SingleOrDefault();

            if (disciplinaDb is null)
                throw new NotFoundException($"Disciplina de ID {disciplinaId} não encontrada");

            if (disciplinaDb.DisciplinasMatricula.Count > 0)
                throw new Exception($"Não é permitido excluir disciplina com estudantes matriculados");

            this.dbSets.Remove(disciplinaDb);
            this.Save();
        }

        private void Save() => this.context.SaveChanges();
    }
}
