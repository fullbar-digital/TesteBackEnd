using Dominio.Entidades;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoDisciplina> CursoDisciplina { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AlunoDisciplina> AlunoDisciplina { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DisciplinaMap());
            builder.ApplyConfiguration(new CursoMap());
            builder.ApplyConfiguration(new CursoDisciplinaMap());
            builder.ApplyConfiguration(new AlunoMap());
            builder.ApplyConfiguration(new AlunoDisciplinaMap());


            #region NxN
            builder.Entity<CursoDisciplina>()
                .HasKey(x => new { x.CursoCodigo, x.DisciplinaCodigo });

            builder.Entity<CursoDisciplina>()
                .HasOne(x => x.Curso)
                .WithMany(x => x.CursoDisciplina)
                .HasForeignKey(x => x.CursoCodigo);

            builder.Entity<CursoDisciplina>()
                .HasOne(x => x.Disciplina)
                .WithMany(x => x.CursoDisciplina)
                .HasForeignKey(x => x.DisciplinaCodigo);



            builder.Entity<AlunoDisciplina>()
                .HasKey(x => new { x.AlunoCodigo, x.DisciplinaCodigo, x.Codigo });

            builder.Entity<AlunoDisciplina>()
                .HasOne(x => x.Aluno)
                .WithMany(x => x.AlunoDisciplina)
                .HasForeignKey(x => x.AlunoCodigo);

            builder.Entity<AlunoDisciplina>()
                .HasOne(x => x.Disciplina)
                .WithMany(x => x.AlunoDisciplina)
                .HasForeignKey(x => x.DisciplinaCodigo);

            #endregion

            #region 1xN
            builder.Entity<Aluno>()
                .HasOne(x => x.Curso)
                .WithMany(x => x.Alunos);
            #endregion
        }
    }
}
