using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Service.Aluno.Aluno;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AlunoService : IAlunoService
    {
        private IRepository<Aluno> _repository;
        private readonly BaseContext _context;
        private IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IRepository<Aluno> repository, IAlunoRepository alunoRepository, IMapper mapper, BaseContext context)
        {
            _repository = repository;
            _context = context;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AlunoDto> Get(Guid id)
        {
            var aluno = _alunoRepository.ListarAlunos();
            var filtro = aluno.Find(o => o.Id.Equals(id));
            var teste = _mapper.Map<AlunoDto>(filtro);

            return teste;
        }

        public async Task<Aluno> Post(AlunoDtoCreate aluno)
        {
            var alunoCreate = _mapper.Map<Aluno>(aluno);

            try
            {
                return await _repository.InsertAsync(alunoCreate);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<Aluno> Put(AlunoDtoUpdate aluno)
        {
            var alunoAll = _alunoRepository.ListarAlunos();
            var filtro = alunoAll.Find(o => o.Id.Equals(aluno.Id));

            if (filtro == null)
                return null;

            filtro.Nome = aluno.Nome;
            filtro.Ra = aluno.Ra;
            filtro.Periodo = aluno.Periodo;
            filtro.Foto = aluno.Foto;
            try
            {
                return await _repository.UpdateAsync(filtro);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<Aluno> ListarAlunos()
        {
            return _alunoRepository.ListarAlunos();
        }

        public Task<List<Aluno>> FiltrarAlunos(string filtrar, string parametro)
        {
            return _alunoRepository.FiltrarAlunos(filtrar, parametro);
        }
    }
}