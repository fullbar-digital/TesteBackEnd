using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICursoService 
    {
        IList<Curso> GetAll();
        void Create(Curso curso);
        void Update(Curso curso);
        void Delete(int id);
    }

    public class CursoService : ICursoService
    {
        private IRepository<Curso> _cursoRepository;

        public CursoService(IRepository<Curso> cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public CursoService()
        {
        }

        public IList<Curso> GetAll()
        {
            return _cursoRepository
                .GetAll()
                .ToList();
        }

        public Curso GetById(int id)
        {
            return _cursoRepository.GetById(id);
        }

        public void Create(Curso curso)
        {
            _cursoRepository.Create(curso);
        }

        public void Delete(int id)
        {
            _cursoRepository.Delete(id);
        }

        public void Update(Curso curso)
        {
            _cursoRepository.Update(curso);
        }
    }
}
