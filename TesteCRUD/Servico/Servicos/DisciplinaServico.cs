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
    public class DisciplinaServico : IDisciplinaServico
    {
        private readonly IMapper _mapper;
        private readonly IDisciplinaRepositorio _disciplinaRepositorio;
        private readonly ICursoDisciplinaRepositorio _cursoDisciplinaRepositorio;

        public DisciplinaServico(IMapper mapper, IDisciplinaRepositorio disciplinaRepositorio, ICursoDisciplinaRepositorio cursoDisciplinaRepositorio)
        {
            _mapper = mapper;
            _disciplinaRepositorio = disciplinaRepositorio;
            _cursoDisciplinaRepositorio = cursoDisciplinaRepositorio;
        }

        public async Task<DisciplinaDTO> Create(DisciplinaDTO disciplinaDTO)
        {
            var disciplina = _mapper.Map<Disciplina>(disciplinaDTO);
            disciplina.DataCriacao = DateTime.Now;

            disciplina.Validate();

            var disciplinaCriada = await _disciplinaRepositorio.Create(disciplina);
            return (_mapper.Map<DisciplinaDTO>(disciplinaCriada));
        }
        public async Task Remove(int codigo)
        {
            var lista = await _cursoDisciplinaRepositorio.ListaPorDisciplina(codigo);
            foreach (var item in lista)
            {
                await _cursoDisciplinaRepositorio.Remove(item.Codigo);
            }
            await _disciplinaRepositorio.Remove(codigo);
        }

        public async Task<DisciplinaDTO> Update(DisciplinaDTO disciplinaDTO)
        {
            var disciplinaExiste = await _disciplinaRepositorio.Get(disciplinaDTO.Codigo);
            if (disciplinaExiste == null)
                throw new DomainException("Não existe essa disciplina para ser alterada");

            var disciplina = _mapper.Map<Disciplina>(disciplinaDTO);
            disciplina.Validate();
            disciplina.AlterarEmpresa(disciplinaDTO.Nome, disciplinaDTO.MinAprovacao);

            var disciplinaAtualizada = await _disciplinaRepositorio.Update(disciplina);
            return _mapper.Map<DisciplinaDTO>(disciplinaAtualizada);
        }

        public async Task<DisciplinaDTO> Get(int codigo)
        {
            var disciplina = await _disciplinaRepositorio.Get(codigo);

            return _mapper.Map<DisciplinaDTO>(disciplina);
        }

        public async Task<List<DisciplinaDTO>> Get()
        {
            var listaDisciplina = await _disciplinaRepositorio.Get();

            return _mapper.Map<List<DisciplinaDTO>>(listaDisciplina);
        }
    }
}
