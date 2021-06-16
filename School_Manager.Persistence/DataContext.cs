using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Manager.Domain;
namespace School_Manager.Persistence
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options){
        }       
        public DbSet<Aluno> Alunos {get; set;}
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Diciplina> Diciplinas {get; set;}
        public DbSet<DiciplinaAluno> DiciplinasAlunos {get; set;}

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiciplinaAluno>()
            .HasKey(DA => new {DA.AlunoId, DA.DiciplinaId});
        }

        internal Task<int> SalveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }   
}