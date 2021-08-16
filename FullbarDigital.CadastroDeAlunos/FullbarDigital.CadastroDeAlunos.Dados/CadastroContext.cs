using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dados
{
    public class CadastroContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Diciplina> Diciplinas { get; set; }
        public DbSet<Historico> Historicos { get; set; }

        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Historico>()
                .HasOne(_ => _.Aluno).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(_ => _.AlunoId);
            modelBuilder.Entity<Historico>()
                .HasOne(_ => _.Diciplina).WithMany().OnDelete(DeleteBehavior.Restrict).HasForeignKey(_ => _.DiciplinaId);
            modelBuilder.Entity<Aluno>()
                .HasMany(_ => _.Historicos).WithOne(_ => _.Aluno).HasForeignKey(_ => _.AlunoId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Diciplina>()
                .HasMany(_ => _.Historicos).WithOne(_ => _.Diciplina);
            base.OnModelCreating(modelBuilder);
        }
    }
}
