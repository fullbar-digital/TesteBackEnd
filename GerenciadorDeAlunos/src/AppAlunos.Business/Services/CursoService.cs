using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Business.Models.Validations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAlunos.Business.Services
{
    public class CursoService : BaseService, ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly ICursoDisciplinaRepository _cursoDisciplinaRepository;
        private readonly IMapper _mapper;

        public CursoService(IDisciplinaRepository disciplinaRepository, ICursoRepository cursoRepository, ICursoDisciplinaRepository cursoDisciplinaRepository,
                                 INotificador notificador, IMapper mapper = null) : base(notificador)
        {
            _disciplinaRepository = disciplinaRepository;
            _cursoRepository = cursoRepository;
            _cursoDisciplinaRepository = cursoDisciplinaRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(Curso curso, IEnumerable<string> nomesDisciplinas)
        {
            try
            {
                if (_cursoRepository.Buscar(f => f.Nome == curso.Nome).Result.Any())
                {
                    Notificar("Já existe um Curso com este nome cadastrado.");
                    return false;
                }

                var disciplinas = _disciplinaRepository.BuscarPorNomes(nomesDisciplinas).ToList();

                if (disciplinas.Count() != nomesDisciplinas.Count())
                {
                    Notificar("É necessário informar disciplinas existentes.");
                    return false;
                }

                List<CursoDisciplina> cursoDisciplina = montarCursoDisciplina(curso, disciplinas);

                await _cursoRepository.Adicionar(curso);

                _cursoDisciplinaRepository.AdicionarLista(cursoDisciplina);

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        private List<CursoDisciplina> montarCursoDisciplina(Curso curso, List<Disciplina> disciplinas)
        {
            List<CursoDisciplinaValidation> cursoDisciplinas = new List<CursoDisciplinaValidation>();

            foreach (var disciplina in disciplinas)
            {
                CursoDisciplinaValidation cursoDisciplina = new CursoDisciplinaValidation();

                cursoDisciplina.CursoId = curso.Id;
                cursoDisciplina.DisciplinaId = disciplina.Id;

                cursoDisciplinas.Add(cursoDisciplina);
            }




            return _mapper.Map<List<CursoDisciplina>>(cursoDisciplinas);

        }

        public void Dispose()
        {
            _cursoRepository?.Dispose();
            _disciplinaRepository?.Dispose();
            _cursoDisciplinaRepository?.Dispose();
        }


    }


}
