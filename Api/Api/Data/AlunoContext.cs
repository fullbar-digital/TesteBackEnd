using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class AlunoContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Password=pastel;Persist Security Info=True;User ID=sa;Initial Catalog=master;Data Source=DESKTOP-NSA7U6T");
        }

        public AlunoContext(DbContextOptions<AlunoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>(Entity =>
            {
                Entity.HasKey(e => new { e.AlunoID, e.DisciplinaID });

            });

            modelBuilder.Entity<AlunoDisciplina>(Entity =>
            {
                Entity.HasKey(e => new { e.AlunoID });

            });

            modelBuilder.Entity<CursoDisciplina>(Entity =>
            {
                Entity.HasKey(e => new { e.CursoID, e.DisciplinaID });

            });
        }
    }
}
