using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{

    public interface IAlunosService
    {
        IList<Alunos> GetAll();
        void Create(Alunos aluno);
        void Update(Alunos aluno);
        void Delete(int id);
    }

    public class AlunosService : IAlunosService
    {
        private IRepository<Alunos> _alunoRepository;

        public AlunosService(IRepository<Alunos> alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public AlunosService()
        {
        }

        public IList<Alunos> GetAll()
        {
            return _alunoRepository
                .GetAll()
                .ToList();
        }

        public Alunos GetById(int id)
        {
            //Regra de Aptovação ou Reprovação na diciplina
            Diciplinas dic = new Diciplinas();
            if(dic.notaMinimaAprovacao > 7.0 )
            {
                Alunos al = new Alunos();
                al.status.Insert(id, "Aprovado");
                
            }
            else if(dic.notaMinimaAprovacao < 7.0)
            {
                Alunos al = new Alunos();
                al.status.Insert(id, "Rerpovado");
            }
            return _alunoRepository.GetById(id);
        }

        public void Create(Alunos curso)
        {
            _alunoRepository.Create(curso);
        }

        public void Delete(int id)
        {
            _alunoRepository.Delete(id);
        }

        public void Update(Alunos curso)
        {
            _alunoRepository.Update(curso);
        }
    }
}
