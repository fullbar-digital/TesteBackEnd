using AutoMapper;
using Domain.Entities;
using Dominio.Entidades;
using Infra.Interfaces;
using Servico.DTO;
using Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Servicos
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IMapper _mapper;
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly ICursoRepositorio _cursoRepositorio;
        private readonly IAlunoDisciplinaRepositorio _alunoDisciplinaRepositorio;
        private readonly IDisciplinaRepositorio _disciplinaRepositorio;
        private readonly ICursoDisciplinaRepositorio _cursoDisciplinaRepositorio;

        public AlunoServico(IMapper mapper, IAlunoRepositorio alunoRepositorio, ICursoRepositorio cursoRepositorio, IAlunoDisciplinaRepositorio alunoDisciplinaRepositorio,
            IDisciplinaRepositorio disciplinaRepositorio, ICursoDisciplinaRepositorio cursoDisciplinaRepositorio)
        {
            _mapper = mapper;
            _alunoRepositorio = alunoRepositorio;
            _cursoRepositorio = cursoRepositorio;
            _alunoDisciplinaRepositorio = alunoDisciplinaRepositorio;
            _disciplinaRepositorio = disciplinaRepositorio;
            _cursoDisciplinaRepositorio = cursoDisciplinaRepositorio;
        }

        public async Task<AlunoDTO> Create(AlunoDTO alunoDTO)
        {
            var aluno = _mapper.Map<Aluno>(alunoDTO);
            aluno.DataCriacao = DateTime.Now;

            aluno.Validate();
            var alunoCriado = await _alunoRepositorio.Create(aluno);
            var listaDisciplinas = await _cursoDisciplinaRepositorio.ListaPorCurso(alunoCriado.CursoCodigo);
            var alunoCriadoDTO = _mapper.Map<AlunoDTO>(alunoCriado);
            alunoCriadoDTO.AlunoDisciplinaDTO = new List<AlunoDisciplinaDTO>();

            foreach (var item in listaDisciplinas)
            {
                var alunoDisciplinaDto = new AlunoDisciplinaDTO(alunoCriado.Codigo, item.DisciplinaCodigo, 0);
                var alunoDisCriado = await AdicionaDisciplina(alunoDisciplinaDto);

                alunoCriadoDTO.AlunoDisciplinaDTO.Add(alunoDisCriado);
            }

            return alunoCriadoDTO;
        }

        public async Task<GetAlunoDTO> Get(int codigo)
        {
            var aluno = await _alunoRepositorio.Get(codigo);
            var curso = await _cursoRepositorio.Get(aluno.CursoCodigo);
            var lista = await _alunoDisciplinaRepositorio.ListaDisciplinas(codigo);

            var alunoDTO = new GetAlunoDTO(aluno.Nome, aluno.RA, aluno.Periodo, aluno.Foto);
            var ListaAlunoDis = new List<GetAlunoDisciplinaDTO>();

            foreach (var item in lista)
            {
                var alunoDis = new GetAlunoDisciplinaDTO(item.Nota, item.Status);
                var disciplina = await _disciplinaRepositorio.Get(item.DisciplinaCodigo);

                alunoDis.NomeDisciplina = disciplina.Nome;
                alunoDis.MinAprovacao = disciplina.MinAprovacao;
                ListaAlunoDis.Add(alunoDis);
            }
            alunoDTO.Disciplinas = ListaAlunoDis;
            alunoDTO.Curso = _mapper.Map<CursoDTO>(curso);

            return alunoDTO;
        }

        public async Task<List<GetAlunoDTO>> ListaPorNome(string nome)
        {
            var ListaAluno = await _alunoRepositorio.ListaAlunoPorNome(nome);
            var listaAlunoDTO = new List<GetAlunoDTO>();

            foreach (var aluno in ListaAluno)
            {
                var curso = await _cursoRepositorio.Get(aluno.CursoCodigo);
                var lista = await _alunoDisciplinaRepositorio.ListaDisciplinas(aluno.Codigo);

                var alunoDTO = new GetAlunoDTO(aluno.Nome, aluno.RA, aluno.Periodo, aluno.Foto);
                var ListaAlunoDis = new List<GetAlunoDisciplinaDTO>();

                foreach (var item in lista)
                {
                    var alunoDis = new GetAlunoDisciplinaDTO(item.Nota, item.Status);
                    var disciplina = await _disciplinaRepositorio.Get(item.DisciplinaCodigo);

                    alunoDis.NomeDisciplina = disciplina.Nome;
                    alunoDis.MinAprovacao = disciplina.MinAprovacao;
                    ListaAlunoDis.Add(alunoDis);
                }
                alunoDTO.Disciplinas = ListaAlunoDis;
                alunoDTO.Curso = _mapper.Map<CursoDTO>(curso);

                listaAlunoDTO.Add(alunoDTO);
            }
            return listaAlunoDTO;
        }

        public async Task<GetAlunoDTO> ListaPorRA(string RA)
        {
            var aluno = await _alunoRepositorio.ListaAlunoPorRA(RA);

            var curso = await _cursoRepositorio.Get(aluno.CursoCodigo);
            var lista = await _alunoDisciplinaRepositorio.ListaDisciplinas(aluno.Codigo);

            var alunoDTO = new GetAlunoDTO(aluno.Nome, aluno.RA, aluno.Periodo, aluno.Foto);
            var ListaAlunoDis = new List<GetAlunoDisciplinaDTO>();

            foreach (var item in lista)
            {
                var alunoDis = new GetAlunoDisciplinaDTO(item.Nota, item.Status);
                var disciplina = await _disciplinaRepositorio.Get(item.DisciplinaCodigo);

                alunoDis.NomeDisciplina = disciplina.Nome;
                alunoDis.MinAprovacao = disciplina.MinAprovacao;
                ListaAlunoDis.Add(alunoDis);
            }
            alunoDTO.Disciplinas = ListaAlunoDis;
            alunoDTO.Curso = _mapper.Map<CursoDTO>(curso);

            return alunoDTO;
        }

        public async Task<List<GetAlunoDTO>> ListaPorStatus(string status)
        {
            var ListaAlunoDisciplina = await _alunoDisciplinaRepositorio.ListaAlunoPorStatus(status);
            var listaAlunoDTO = new List<GetAlunoDTO>();

            foreach (var listaDisciplina in ListaAlunoDisciplina)
            {
                var aluno = await _alunoRepositorio.Get(listaDisciplina.AlunoCodigo);
                var curso = await _cursoRepositorio.Get(aluno.CursoCodigo);
                var lista = await _alunoDisciplinaRepositorio.ListaDisciplinas(aluno.Codigo);

                var alunoDTO = new GetAlunoDTO(aluno.Nome, aluno.RA, aluno.Periodo, aluno.Foto);
                var ListaAlunoDis = new List<GetAlunoDisciplinaDTO>();

                foreach (var item in lista)
                {
                    var alunoDis = new GetAlunoDisciplinaDTO(item.Nota, item.Status);
                    var disciplina = await _disciplinaRepositorio.Get(item.DisciplinaCodigo);

                    alunoDis.NomeDisciplina = disciplina.Nome;
                    alunoDis.MinAprovacao = disciplina.MinAprovacao;
                    ListaAlunoDis.Add(alunoDis);
                }
                alunoDTO.Disciplinas = ListaAlunoDis;
                alunoDTO.Curso = _mapper.Map<CursoDTO>(curso);

                listaAlunoDTO.Add(alunoDTO);
            }
            return listaAlunoDTO;
        }
        //
        public async Task<List<GetAlunoDTO>> ListaPorCurso(string nomeCurso)
        {
            var ListaCurso = await _cursoRepositorio.ListaCursoPorNome(nomeCurso);
            var listaAlunoDTO = new List<GetAlunoDTO>();

            foreach (var curso in ListaCurso)
            {
                var listaAluno = await _alunoRepositorio.ListaAlunoPorCurso(curso.Codigo);
                foreach (var AlunoItem in listaAluno)
                {
                    var lista = await _alunoDisciplinaRepositorio.ListaDisciplinas(AlunoItem.Codigo);

                    var alunoDTO = new GetAlunoDTO(AlunoItem.Nome, AlunoItem.RA, AlunoItem.Periodo, AlunoItem.Foto);
                    var ListaAlunoDis = new List<GetAlunoDisciplinaDTO>();

                    foreach (var item in lista)
                    {
                        var alunoDis = new GetAlunoDisciplinaDTO(item.Nota, item.Status);
                        var disciplina = await _disciplinaRepositorio.Get(item.DisciplinaCodigo);

                        alunoDis.NomeDisciplina = disciplina.Nome;
                        alunoDis.MinAprovacao = disciplina.MinAprovacao;
                        ListaAlunoDis.Add(alunoDis);
                    }
                    alunoDTO.Disciplinas = ListaAlunoDis;
                    alunoDTO.Curso = _mapper.Map<CursoDTO>(curso);

                    listaAlunoDTO.Add(alunoDTO);
                }                
            }
            return listaAlunoDTO;
        }

        public async Task<List<AlunoDTO>> Get()
        {
            var listaAluno = await _alunoRepositorio.Get();

            return _mapper.Map<List<AlunoDTO>>(listaAluno);
        }

        public async Task Remove(int codigo)
        {
            var lista = await _alunoDisciplinaRepositorio.ListaDisciplinas(codigo);
            foreach(var item in lista)
            {
                await _alunoDisciplinaRepositorio.Remove(item.Codigo);
            }
            await _alunoRepositorio.Remove(codigo);
        }

        public async Task<AlunoDTO> Update(AlunoDTO alunoDTO)
        {
            var alunoExiste = await _alunoRepositorio.Get(alunoDTO.Codigo);
            if (alunoExiste == null)
                throw new DomainException("Não existe esse aluno para ser alterado");

            var aluno = _mapper.Map<Aluno>(alunoDTO);
            aluno.DataCriacao = DateTime.Now;

            aluno.Validate();
            aluno.AlterarAluno(alunoDTO.Nome, alunoDTO.RA, alunoDTO.Periodo, alunoDTO.Foto, alunoDTO.CursoCodigo);

            var alunoAlterado = await _alunoRepositorio.Update(aluno);
            return _mapper.Map<AlunoDTO>(alunoAlterado);
        }

        public async Task<AlunoDisciplinaDTO> AdicionaDisciplina(AlunoDisciplinaDTO alunoDTO)
        {
            var aluno = _mapper.Map<AlunoDisciplina>(alunoDTO);
            var disciplina = await _disciplinaRepositorio.Get(alunoDTO.DisciplinaCodigo);
            aluno.Status = aluno.Nota >= disciplina.MinAprovacao ? "Aprovado" : "Reprovado";
            aluno.DataCriacao = DateTime.Now;

            aluno.Validate();
            var alunoCriado = await _alunoDisciplinaRepositorio.Create(aluno);
            return _mapper.Map<AlunoDisciplinaDTO>(alunoCriado);
        }

        public async Task<AlunoDisciplinaDTO> AdicionaNota(AlunoDisciplinaDTO alunoDTO)
        {
            var alunoExiste = await _alunoDisciplinaRepositorio.ListaPorAlunoDisciplina(alunoDTO.AlunoCodigo, alunoDTO.DisciplinaCodigo);
            if (alunoExiste == null)
                throw new DomainException("Não existe esse aluno para ser adicionado nota");

            var aluno = _mapper.Map<AlunoDisciplina>(alunoDTO);
            var disciplina = await _disciplinaRepositorio.Get(alunoDTO.DisciplinaCodigo);
            var status = aluno.Nota >= disciplina.MinAprovacao ? "Aprovado" : "Reprovado";

            aluno.alterarNota(alunoDTO.Nota, status, alunoExiste.DataCriacao, alunoExiste.Codigo);


            aluno.Validate();
            var alunoCriado = await _alunoDisciplinaRepositorio.Update(aluno);
            return _mapper.Map<AlunoDisciplinaDTO>(alunoCriado);
        }
    }
}
