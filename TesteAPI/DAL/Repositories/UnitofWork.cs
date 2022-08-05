using System;

namespace TesteAPI.DAL.Repositories
{
    public class UnitofWork : Interfaces.IUnitOfWork
    {
        private readonly Contexto _context;

        private Interfaces.IRepository<MLL.Aluno> _alunoRepository = null;
        private Interfaces.IRepository<MLL.Curso> _cursoRepository = null;
        private Interfaces.IRepository<MLL.Disciplina> _disciplinaRepository = null;
        private Interfaces.IRepository<MLL.Usuario> _usuarioRepository = null;
        private Interfaces.IRepository<MLL.AlunoNota> _alunoNotaRepository = null;
        public Exception _erro = null;

        public UnitofWork(Contexto context)
        {
            _context = context;
        }

        public Interfaces.IRepository<MLL.Aluno> AlunoRepositorio
        {
            get
            {
                if (_alunoRepository == null)
                    _alunoRepository = new Repository<MLL.Aluno>(_context);
                return _alunoRepository;
            }
        }

        public Interfaces.IRepository<MLL.Curso> CursoRepositorio
        {
            get
            {
                if (_cursoRepository == null)
                    _cursoRepository = new Repository<MLL.Curso>(_context);
                return _cursoRepository;
            }
        }

        public Interfaces.IRepository<MLL.Disciplina> DisciplinaRepositorio
        {
            get
            {
                if (_disciplinaRepository == null)
                    _disciplinaRepository = new Repository<MLL.Disciplina>(_context);
                return _disciplinaRepository;
            }
        }

        public Interfaces.IRepository<MLL.Usuario> UsuarioRepositorio
        {
            get
            {
                if (_usuarioRepository == null)
                    _usuarioRepository = new Repository<MLL.Usuario>(_context);
                return _usuarioRepository;
            }
        }

        public Interfaces.IRepository<MLL.AlunoNota> AlunoNotaRepositorio
        {
            get
            {
                if (_alunoNotaRepository == null)
                    _alunoNotaRepository = new Repository<MLL.AlunoNota>(_context);
                return _alunoNotaRepository;
            }
        }

        public bool Commit()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;

                return false;
            }
        }
    }
}
