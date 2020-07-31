using System;
using System.Collections.Generic;
using CRUD.BLL.Interfaces;
using CRUD.DAL.Interfaces;
using CRUD.Model;
using CRUD.ViewModel;

namespace CRUD.BLL
{
    public class AlunoBusiness : IAlunoBusiness
    {
        protected IAlunoRepository repository;

        public AlunoBusiness(IAlunoRepository _repository)
        {
            repository = _repository;
        }

        public bool Delete(int id)
        {
            Aluno aluno = repository.GetById(id);

            return repository.Delete(aluno);
        }

        public List<AlunoViewModel> GetAll()
        {
            List<AlunoViewModel> list = new List<AlunoViewModel>();
            repository.GetAll().ForEach(x =>
            {
                list.Add(new AlunoViewModel(x));
            });
            return list;
        }

        public List<AlunoViewModel> GetByFilter(FilterViewModel filter)
        {
            List<AlunoViewModel> list = new List<AlunoViewModel>();
            repository.GetByFilter(filter).ForEach(x =>
            {
                list.Add(new AlunoViewModel(x));
            });
            return list;
        }

        public AlunoViewModel GetById(int id)
        {
            Aluno aluno = repository.GetById(id);
            return new AlunoViewModel(aluno);
        }

        public bool Save(AlunoViewModel aluno)
        {
            Aluno _aluno = new Aluno()
            {
                Nome = aluno.nome,
                Curso = aluno.curso,
                Nota = int.Parse(aluno.nota),
                RA = aluno.registroAcademico,
                Periodo = int.Parse(aluno.periodo)
            };

            return repository.Insert(_aluno);
        }

        public bool Update(int id, AlunoViewModel aluno)
        {

            Aluno _aluno = repository.GetById(id);

            _aluno.Nome = aluno.nome;
            _aluno.Curso = aluno.curso;
            _aluno.Nota = int.Parse(aluno.nota);
            _aluno.RA = aluno.registroAcademico;
            _aluno.Periodo = int.Parse(aluno.periodo);


            return repository.Update(_aluno);
        }
    }
}
