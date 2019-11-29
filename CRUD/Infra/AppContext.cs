using System;
using CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infra
{
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Aluno>()
            .HasKey(c => new { c.Id });

        }
    }
}


