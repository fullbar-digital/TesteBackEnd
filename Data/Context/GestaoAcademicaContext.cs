using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class GestaoAcademicaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasKey(a => new { a.AlunoId });

            modelBuilder.Entity<Curso>()
                .HasKey(c => new { c.CursoId });

            modelBuilder.Entity<Disciplina>()
                .HasKey(c => new { c.DisciplinaId });

            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new {ad.AlunoDisciplinaId});

            modelBuilder.Entity<AlunoDisciplina>()
            .HasOne(ad => ad.Aluno)
            .WithMany(a => a.AlunosDisciplinas)
            .HasForeignKey(ad => ad.AlunoId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AlunoDisciplina>()
            .HasOne(ad => ad.Disciplina)
            .WithMany(d => d.AlunosDisciplinas)
            .HasForeignKey(ad => ad.DisciplinaId)
            .OnDelete(DeleteBehavior.NoAction);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GestaoAcademica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
