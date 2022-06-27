using Microsoft.EntityFrameworkCore;
using Teste.Domain.Alunos.Entities;
using Teste.Domain.Cursos.Entitites;
using Teste.Domain.Disciplinas.Entities;
using Teste.Infra.Data.Mappings;

namespace Teste.Infra.Data.Contexts
{
    public class TesteContexto : DbContext
    {
        public TesteContexto(DbContextOptions<TesteContexto> options) : base(options)
        {
        }

        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new AlunoConfigurations().ConfigureProperties(modelBuilder.Entity<Aluno>());
            new DisciplinaConfigurations().ConfigureProperties(modelBuilder.Entity<Disciplina>());
            new CursoConfigurations().ConfigureProperties(modelBuilder.Entity<Curso>());
        }
    }
}
