using BancoAlunos.Data.DataModels;
using BancoAlunos.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoAlunos.Data
{
    public class AlunosContext : DbContext
    {
        #region CtorsDbContextOptions
        public AlunosContext()
        {

        }

        public AlunosContext(DbContextOptions<AlunosContext> options) : base(options)
        {

        }
        #endregion

        #region Props
        public DbSet<Alunos> DbAlunos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AlunosDataModel());
        }
    }
}
