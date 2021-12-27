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
    public class CursoServico : ICursoServico
    {
        private readonly IMapper _mapper;
        private readonly ICursoRepositorio _cursoRepositorio;
        private readonly ICursoDisciplinaRepositorio _cursoDisciplinaRepositorio;

        public CursoServico(IMapper mapper, ICursoRepositorio cursoRepositorio, ICursoDisciplinaRepositorio cursoDisciplinaRepositorio)
        {
            _mapper = mapper;
            _cursoRepositorio = cursoRepositorio;
            _cursoDisciplinaRepositorio = cursoDisciplinaRepositorio;
        }

        public async Task<CursoDTO> Create(CursoDTO cursoDTO)
        {
            var curso =_mapper.Map<Curso>(cursoDTO);
            curso.DataCriacao = DateTime.Now;

            curso.Validate();
            var cursoCriado = await _cursoRepositorio.Create(curso);
            var cursoRetorno = _mapper.Map<CursoDTO>(cursoCriado);
            cursoRetorno.CursoDisciplinas = new List<CursoDisciplinaDTO>();

            foreach (var item in cursoDTO.CodigoDisciplinas)
            {
                var cursoDisciplinaDTO = new CursoDisciplinaDTO(cursoCriado.Codigo, item);
                var cursoDisciplina = _mapper.Map<CursoDisciplina>(cursoDisciplinaDTO);
                cursoDisciplina.DataCriacao = DateTime.Now;

                cursoDisciplina.Validate();
                var cursoDisplinaCriado = await _cursoDisciplinaRepositorio.Create(cursoDisciplina);
                cursoRetorno.CursoDisciplinas.Add(_mapper.Map<CursoDisciplinaDTO>(cursoDisplinaCriado));
            }
            return (cursoRetorno);
        }

        public async Task<CursoDTO> Get(int codigo)
        {
            var curso = await _cursoRepositorio.Get(codigo);

            return (_mapper.Map<CursoDTO>(curso));
        }

        public async Task<List<CursoDTO>> Get()
        {

            var ListaCursos = await _cursoRepositorio.Get();

            return (_mapper.Map<List<CursoDTO>>(ListaCursos));
        }

        public async Task Remove(int codigo)
        {
            var lista = await _cursoDisciplinaRepositorio.ListaPorCurso(codigo);
            foreach (var item in lista)
            {
                await _cursoDisciplinaRepositorio.Remove(item.Codigo);
            }
            await _cursoRepositorio.Remove(codigo);
        }

        public async Task<CursoDTO> Update(CursoDTO cursoDTO)
        {
            var cursoexiste = await _cursoRepositorio.Get(cursoDTO.Codigo);
            if (cursoexiste == null)
                throw new DomainException("Não Existe esse curso para ser alterado");

            var curso = _mapper.Map<Curso>(cursoDTO);
            curso.Validate();
            curso.AlterarCurso(cursoDTO.Nome);

            var cursoAlterado = await _cursoRepositorio.Update(curso);
            return (_mapper.Map<CursoDTO>(cursoAlterado));

        }

        public async Task<CursoDisciplinaDTO> AddDisciplina(CursoDisciplinaDTO cursoDisciplinaDTO)
        {
            var cursoDisciplina = _mapper.Map<CursoDisciplina>(cursoDisciplinaDTO);
            cursoDisciplina.DataCriacao = DateTime.Now;

            cursoDisciplina.Validate();
            var cursoDisplinaCriado = await _cursoDisciplinaRepositorio.Create(cursoDisciplina);
            return (_mapper.Map<CursoDisciplinaDTO>(cursoDisplinaCriado));
        }

        public async Task DelDisciplina(CursoDisciplinaDTO cursoDisciplinaDTO)
        {
            var cursoDis = _mapper.Map<CursoDisciplina>(cursoDisciplinaDTO);
            cursoDis.DataCriacao = DateTime.Now;

            cursoDis.Validate();
            var cursoDisplina = await _cursoDisciplinaRepositorio.ListaPorCursoDisciplina(cursoDis);

            await _cursoDisciplinaRepositorio.Remove(cursoDisplina.Codigo);
        }
    }
}
