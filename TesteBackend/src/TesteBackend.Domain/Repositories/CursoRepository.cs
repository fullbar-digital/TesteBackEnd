using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TesteBackend.Domain.Exceptions;
using TesteBackend.Domain.Models;

namespace TesteBackend.Domain.Repositories
{
    public interface ICursoRepository
    {
        public Curso Add(Curso curso);
        public Curso Get(int cursoId);
        public Curso Edit(Curso curso);
        public void Delete(int cursoId);
    }

    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(DbBackendContext context) : base(context)
        {
        }

        /// <summary>
        /// Adicionar curso
        /// </summary>
        /// <param name="curso">Curso para cadastro</param>
        /// <returns>Retorna curso cadastrado</returns>
        public Curso Add(Curso curso)
        {
            if (string.IsNullOrWhiteSpace(curso.Nome))
                throw new ArgumentNullException("O nome do curso não pode ser vazio");
            
            this.dbSets.Add(curso);
            this.Save();
            return curso;
        }

        /// <summary>
        /// Consultar curso
        /// </summary>
        /// <param name="cursoId">Identificador do curso</param>
        /// <returns>Retorna curso</returns>
        public Curso Get(int cursoId)
        {
            Curso curso = this.dbSets
                                .Include(c => c.Disciplinas)
                                .Include(c => c.Alunos)
                                .Where(c => c.Id == cursoId)
                                .FirstOrDefault();

            return curso;
        }

        /// <summary>
        /// Editar os dados do curso
        /// </summary>
        /// <param name="curso">Curso para alteração</param>
        /// <returns>Retorna curso</returns>
        public Curso Edit(Curso curso)
        {
            Curso cursoDb = this.dbSets.Where(c => c.Id == curso.Id).SingleOrDefault();

            if (cursoDb is null)
                throw new NotFoundException($"Curso de ID {curso.Id} não foi localizado");

            cursoDb.Nome = curso.Nome;

            this.Save();
            return cursoDb;
        }

        /// <summary>
        /// Excluir curso
        /// </summary>
        /// <param name="cursoId">Identificador do curso</param>
        public void Delete(int cursoId)
        {
            Curso curso = this.dbSets
                              .Include(c => c.Disciplinas)
                              .Include(c => c.Alunos)
                              .Where(c => c.Id == cursoId)
                              .SingleOrDefault();

            if (curso is null)
                throw new NotFoundException($"Curso de ID {cursoId} não foi localizado");
            
            if (curso.Disciplinas.Count > 0)
                throw new Exception("Não é permitido excluir curso com disciplinas vinculadas");

            if (curso.Alunos.Count > 0)
                throw new Exception("Não é permitido excluir curso com alunos matriculados");

            this.dbSets.Remove(curso);
            this.Save();
        }

        private void Save() => this.context.SaveChanges();
    }
}
