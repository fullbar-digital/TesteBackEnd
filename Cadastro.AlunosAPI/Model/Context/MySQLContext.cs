using Microsoft.EntityFrameworkCore;


namespace Cadastro.AlunosAPI.Model.Context
{
    public class MySQLContext:DbContext
    {
        public MySQLContext() {}
        public MySQLContext(DbContextOptions<MySQLContext> options): base (options) { }

        public DbSet<Alunos> Alunos { get; set; }
    }
}
