using AutoMapper;
using Fullbar.Teste.Api.Controllers;
using Fullbar.Teste.Api.ViewModels;
using Fullbar.Teste.Application.Interfaces;
using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fullbar.Teste.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cursos")]
    public class CursosController : MainController
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly ICursoService _cursoService;
        private readonly IMapper _mapper;

        public CursosController(INotificador notificador,
                                  ICursoRepository cursoRepository,
                                  ICursoService cursoService,
                                  IMapper mapper) : base(notificador)
        {
            _cursoRepository = cursoRepository;
            _cursoService = cursoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CursoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(await _cursoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CursoViewModel>> ObterPorId(Guid id)
        {
            var cursoViewModel = await ObterCurso(id);

            if (cursoViewModel == null) return NotFound();

            return cursoViewModel;
        }


        [HttpPost]
        public async Task<ActionResult<CursoViewModel>> Adicionar(CursoViewModel cursoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cursoService.Adicionar(_mapper.Map<Curso>(cursoViewModel));

            return CustomResponse(cursoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, CursoViewModel cursoViewModel)
        {
            if (id != cursoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var cursoAtualizacao = await ObterCurso(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            cursoAtualizacao.Nome = cursoViewModel.Nome;

            await _cursoService.Atualizar(_mapper.Map<Curso>(cursoAtualizacao));

            return CustomResponse(cursoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CursoViewModel>> Excluir(Guid id)
        {
            var curso = await ObterCurso(id);

            if (curso == null) return NotFound();

            await _cursoService.Remover(id);

            return CustomResponse(curso);
        }

        private async Task<CursoViewModel> ObterCurso(Guid id)
        {
            return _mapper.Map<CursoViewModel>(await _cursoRepository.ObterPorId(id));
        }

    }
}