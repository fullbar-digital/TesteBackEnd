using AppAlunos.Api.Models.Request;
using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Business.Models.Request;
using AppAlunos.Business.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAlunos.Business.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IAlunoDisciplinaRepository _alunoDisciplinaRepository;

        public AlunoService(IAlunoRepository alunoRepository,
                                 ICursoRepository cursoRepository,
                                 IDisciplinaRepository disciplinaRepository,
                                 IAlunoDisciplinaRepository alunoDisciplinaRepository,
                                 INotificador notificador) : base(notificador)
        {
            _alunoRepository = alunoRepository;
            _cursoRepository = cursoRepository;
            _disciplinaRepository = disciplinaRepository;
            _alunoDisciplinaRepository = alunoDisciplinaRepository;
        }

        public async Task<Aluno> Adicionar(AlunoRequest alunoRequest)
        {

            if (_alunoRepository.Buscar(f => f.RegistroAcademico == alunoRequest.RegistroAcademico).Result.Any())
            {
                Notificar("Já existe Aluno com este RA cadastrado.");
                return null;
            }

            Curso curso = _cursoRepository.BuscarPorNome(alunoRequest.NomeCurso);

            if (curso == null)
            {
                Notificar("É necessário informar um Curso existente.");
                return null;
            }

            var nomesDisciplinas = alunoRequest.DadosDisciplinas.Select(dd => dd.NomeDisciplina);

            var disciplinas = _disciplinaRepository.BuscarPorNomes(nomesDisciplinas).ToList();

            if (nomesDisciplinas.Count() != disciplinas.Count())
            {
                Notificar("É necessário informar Disciplinas existentes.");
                return null;
            }

            Aluno aluno = montarAlunoEntity(alunoRequest, curso);

            await _alunoRepository.Adicionar(aluno);

            List<AlunoDisciplina> alunoDisciplina = montarAlunoDisciplinas(aluno, disciplinas, alunoRequest.DadosDisciplinas);

            _alunoDisciplinaRepository.AdicionarLista(alunoDisciplina);

            return aluno;
        }

        public async Task<bool> Atualizar(Aluno aluno)
        {
            await _alunoRepository.Atualizar(aluno);

            return true;
        }

        public IEnumerable<AlunoResponse> ListarAlunos()
        {

            var dadosAlunos = _alunoRepository.RetornarAlunosCursoDisciplina();

            var alunosRetorno = montarRetornoDeAlunos(dadosAlunos);

            return alunosRetorno;
        }

        public IEnumerable<AlunoResponse> ListarPorFiltro(string filtro, string valor)
        {
            var dadosAlunos = _alunoRepository.RetornarAlunosFiltro(filtro, valor);

            var alunosRetorno = montarRetornoDeAlunos(dadosAlunos);

            return alunosRetorno;
        }

        public async Task AtualizarCurso(Curso curso)
        {
            await _cursoRepository.Atualizar(curso);
        }

        public async Task<bool> Remover(Guid id)
        {
            var aluno = _alunoRepository.Buscar(aluno => aluno.Id == id).Result.FirstOrDefault();
            if (aluno == null)
                return false;

            var alunosDisciplinas = await _alunoDisciplinaRepository.Buscar(x => x.AlunoId == id);

            if (alunosDisciplinas != null)
                await _alunoDisciplinaRepository.RemoverLista(alunosDisciplinas);

            await _alunoRepository.RemoverAsync(id);
            return true;
        }

        private Aluno montarAlunoEntity(AlunoRequest alunoRequest, Curso curso)
        {
            Aluno aluno = new Aluno();

            aluno.Id = alunoRequest.Id;
            aluno.Nome = alunoRequest.Nome;
            aluno.Periodo = alunoRequest.Periodo;
            aluno.RegistroAcademico = alunoRequest.RegistroAcademico;
            aluno.Foto = alunoRequest.Foto;
            aluno.CursoId = curso.Id;


            return aluno;
        }

        private List<AlunoDisciplina> montarAlunoDisciplinas(Aluno aluno, List<Disciplina> disciplinas, List<AlunoDisciplinaRequest> dadosAlunoDisciplina)
        {
            List<AlunoDisciplina> alunoDisciplinas = new List<AlunoDisciplina>();

            foreach (var disciplina in disciplinas)
            {
                double nota = dadosAlunoDisciplina.Where(x => x.NomeDisciplina == disciplina.Nome).Select(da => da.NotaDaDisciplina).FirstOrDefault();

                AlunoDisciplina alunoDisciplina = new AlunoDisciplina();

                alunoDisciplina.AlunoId = aluno.Id;
                alunoDisciplina.DisciplinaId = disciplina.Id;
                alunoDisciplina.Nota = nota;
                alunoDisciplina.Status = nota >= disciplina.NotaMinimaAprovacao ? "Aprovado" : "Reprovado";

                alunoDisciplinas.Add(alunoDisciplina);
            }

            return alunoDisciplinas;

        }

        private List<AlunoResponse> montarRetornoDeAlunos(List<Aluno> alunos)
        {
            List<AlunoResponse> alunosResponses = new List<AlunoResponse>();

            foreach (var aluno in alunos)
            {
                AlunoResponse alunoResponse = new AlunoResponse();

                alunoResponse.Id = aluno.Id;
                alunoResponse.Nome = aluno.Nome;
                alunoResponse.CursoId = aluno.CursoId;
                alunoResponse.RegistroAcademico = aluno.RegistroAcademico;
                alunoResponse.Periodo = aluno.Periodo;
                alunoResponse.Foto = aluno.Foto;
                alunoResponse.DadosDisciplina = aluno.AlunosDisciplinas.Where(x => x.AlunoId == aluno.Id).Select(x => new DisciplinaResponse { Id = x.DisciplinaId, NotaAluno = x.Nota, Status = x.Status }).ToList();
                alunosResponses.Add(alunoResponse);
            }

            return alunosResponses;
        }

        public void Dispose()
        {
            _alunoRepository?.Dispose();
            _cursoRepository?.Dispose();
            _disciplinaRepository?.Dispose();
            _alunoDisciplinaRepository?.Dispose();
        }
    }
}