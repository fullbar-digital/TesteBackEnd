namespace TesteAPI.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Interfaces.IRepository<MLL.Aluno> AlunoRepositorio { get; }
        Interfaces.IRepository<MLL.Curso> CursoRepositorio { get; }
        Interfaces.IRepository<MLL.Disciplina> DisciplinaRepositorio { get; }
        Interfaces.IRepository<MLL.Usuario> UsuarioRepositorio { get; }
        Interfaces.IRepository<MLL.AlunoNota> AlunoNotaRepositorio { get; }

        bool Commit();
    }
}
