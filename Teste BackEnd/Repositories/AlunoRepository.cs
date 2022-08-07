using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Teste_BackEnd.Interfaces;
using Teste_BackEnd.Models;

namespace Teste_BackEnd.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        ICursoRepository _cursoRepository;
        IDisciplinaRepository _disciplinaRepository;


        public AlunoRepository(ApplicationContext context,
                                ICursoRepository cursoRepository,
                                IDisciplinaRepository disciplinaRepository) : base(context)
        {
            _cursoRepository = cursoRepository;
            _disciplinaRepository = disciplinaRepository;

        }

        public void Add(Aluno obj)
        {
            Curso curso = _cursoRepository.GetByNome(obj.Curso.Nome);

            // Caso curso já exista, verifica se todas as disciplinas já existem. Caso não, insere
            if (curso != null)
            {
                foreach (Disciplina d in obj.Curso.Disciplinas)
                {
                    var disciplina = _disciplinaRepository.GetByNome(d.Nome, curso.Id);
                    if (disciplina == null)
                    {
                        d.CursoId = curso.Id;
                        _disciplinaRepository.Add(d);
                    }
                }

                obj.CursoId = curso.Id;
                obj.Curso = null;

            }

            dbSet.Add(obj);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var aluno = GetById(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrado");

            dbSet.Remove(aluno);

            context.SaveChanges();
        }

        public IList<Aluno> GetAll()
        {
            var alunos = context
                        .Alunos
                        .Include(c => c.Curso)
                        .ThenInclude(d => d.Disciplinas)
                        .ToList(); 

            return alunos;
        }

        public IList<Aluno> GetByCurso(int cursoId)
        {
            var alunos = context
                        .Alunos
                        .Include(c => c.Curso)
                        .ThenInclude(d => d.Disciplinas)
                        .Where(a => a.CursoId == cursoId)
                        .ToList(); 

            return alunos;
        }

        public Aluno GetById(int id)
        {
            var aluno = context
                        .Alunos
                        .Include(c => c.Curso)
                        .ThenInclude(d => d.Disciplinas)
                        .Where(a => a.Id == id)
                        .FirstOrDefault();

            return aluno;
        }

        public Aluno GetByNome(string nome)
        {
            var aluno = context
                        .Alunos
                        .Include(c => c.Curso)
                        .ThenInclude(d => d.Disciplinas)
                        .Where(a => a.Nome == nome)
                        .FirstOrDefault();

            return aluno;
        }

        public Aluno GetByRA(string ra)
        {
            var aluno = context
                        .Alunos
                        .Include(c => c.Curso)
                        .ThenInclude(d => d.Disciplinas)
                        .Where(a => a.RA == ra)
                        .FirstOrDefault();

            return aluno;
        }

        public IList<Aluno> GetByStatus(string status)
        {
            var alunos = context
                        .Alunos
                        .Include(c => c.Curso)
                        .ThenInclude(d => d.Disciplinas)
                        .Where(a => a.Status == status)
                        .ToList();

            return alunos;
        }

        public Aluno Update(int id, Aluno obj)
        {
            var aluno = GetById(id);

            if (aluno == null)
                throw new Exception("Aluno não encontrad");

            aluno.Nome = obj.Nome;
            aluno.RA = obj.RA;
            aluno.Periodo = obj.Periodo;
            aluno.Foto = obj.Foto;

            dbSet.Update(aluno);

            context.SaveChanges();

            return aluno;
        }
    }
}
