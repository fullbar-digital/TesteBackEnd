using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TesteAPI.DAL
{
    public class Contexto : DbContext, Interfaces.IContexto
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.OpenConnection();
            //Database.Migrate();
        }      

        public DbSet<MLL.Usuario> Usuarios { get; set; }
        public DbSet<MLL.Aluno> Alunos { get; set; }
        public DbSet<MLL.Curso> Cursos { get; set; }
        public DbSet<MLL.Disciplina> Disciplinas { get; set; }
        public DbSet<MLL.AlunoNota> AlunoNotas { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{         

        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\TesteApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DAL.Mapeamento.UsuarioMAP());
            modelBuilder.ApplyConfiguration(new DAL.Mapeamento.AlunoMAP());
            modelBuilder.ApplyConfiguration(new DAL.Mapeamento.CursoMAP());
            modelBuilder.ApplyConfiguration(new DAL.Mapeamento.DisciplinaMAP());
            modelBuilder.ApplyConfiguration(new DAL.Mapeamento.AlunoNotaMAP());



            //Relacionamentos 1 x N
            modelBuilder.Entity<MLL.Curso>()
                .HasMany(x => x.Disciplinas)
                .WithOne(y => y.Curso)
                .HasForeignKey(y => y.CursoCodigo);




            //Relacionamentos N x N
            //modelBuilder.Entity<MLL.AlunoNota>().HasKey(sc => new { sc.AlunoCodigo, sc.DisciplinaCodigo });
            modelBuilder.Entity<MLL.AlunoNota>()
                     .HasOne<MLL.Aluno>(sc => sc.Aluno)
                       .WithMany(s => s.Notas)
                     .HasForeignKey(sc => sc.AlunoCodigo);
           

        }
    }
}
