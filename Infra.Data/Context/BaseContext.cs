using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class BaseContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<RelacaoAlunoDisciplina> RelacaoAlunoDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>(new AlunoMap().Configure);
            modelBuilder.Entity<Curso>(new CursoMap().Configure);
            modelBuilder.Entity<Disciplina>(new DisiciplinaMap().Configure);
            modelBuilder.Entity<RelacaoAlunoDisciplina>(new RelacaoAlunoDisciplinaMap().Configure);
        }
    }
}