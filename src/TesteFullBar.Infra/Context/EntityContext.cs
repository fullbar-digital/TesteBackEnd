using Microsoft.EntityFrameworkCore;
using TesteFullBar.Domain.Models;
using TesteFullBar.Infra.Mappings;

namespace TesteFullBar.Infra.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options)
             : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new AlunoDisciplinaMap());
        }
    }
}
