using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{

    public interface IDiciplinaService
    {
        IList<Diciplinas> GetAll();
        void Create(Diciplinas diciplina);
        void Update(Diciplinas diciplina);
        void Delete(int id);
    }

    public class DiciplinaService : IDiciplinaService
    {
        private IRepository<Diciplinas> _diciplinaRepository;

        public DiciplinaService(IRepository<Diciplinas> diciplinaRepository)
        {
            _diciplinaRepository = diciplinaRepository;
        }

        public DiciplinaService()
        {
        }

        public IList<Diciplinas> GetAll()
        {
            return _diciplinaRepository
                .GetAll()
                .ToList();
        }

        public Diciplinas GetById(int id)
        {
            return _diciplinaRepository.GetById(id);
        }

        public void Create(Diciplinas diciplina)
        {
            _diciplinaRepository.Create(diciplina);
        }

        public void Delete(int id)
        {
            _diciplinaRepository.Delete(id);
        }

        public void Update(Diciplinas diciplina)
        {
            _diciplinaRepository.Update(diciplina);
        }
    }
}
