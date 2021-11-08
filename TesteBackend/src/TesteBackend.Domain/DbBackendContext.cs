using Microsoft.EntityFrameworkCore;
using TesteBackend.Domain.DataConfiguration;
using TesteBackend.Domain.Models;

namespace TesteBackend.Domain
{
    public class DbBackendContext : DbContext
    {
        internal DbSet<Aluno> Alunos { get; set; }
        internal DbSet<Curso> Cursos { get; set; }
        internal DbSet<Disciplina> Disciplinas { get; set; }
        internal DbSet<Matricula> Matriculas { get; set; }

        public DbBackendContext(DbContextOptions options) : base(options)
        {
        }

        protected DbBackendContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinaConfiguration());
            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new MatriculaConfiguration());
        }

    }
}
