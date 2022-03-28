using Api.Models;
using Infra.EntityConfigs;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AlunosContext : DbContext
    {
        public AlunosContext(DbContextOptions<AlunosContext> option)
            :base(option) { }

        #region
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<CursoDisciplina> CursoDisciplinas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfig());

            modelBuilder.ApplyConfiguration(new AlunoDisciplinaConfig());

            modelBuilder.ApplyConfiguration(new CursoDisciplinaConfig());

            modelBuilder.ApplyConfiguration(new DisciplinaConfig());

            modelBuilder.ApplyConfiguration(new CursoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
