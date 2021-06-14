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
    [Route("api/v{version:apiVersion}/disciplinas")]
    public class DisciplinasController : MainController
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IDisciplinaService _disciplinaService;
        private readonly IMapper _mapper;

        public DisciplinasController(INotificador notificador,
                                  IDisciplinaRepository disciplinaRepository,
                                  IDisciplinaService disciplinaService,
                                  IMapper mapper) : base(notificador)
        {
            _disciplinaRepository = disciplinaRepository;
            _disciplinaService = disciplinaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DisciplinaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<DisciplinaViewModel>>(await _disciplinaRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DisciplinaViewModel>> ObterPorId(Guid id)
        {
            var disciplinaViewModel = await ObterDisciplina(id);

            if (disciplinaViewModel == null) return NotFound();

            return disciplinaViewModel;
        }


        [HttpPost]
        public async Task<ActionResult<DisciplinaViewModel>> Adicionar(DisciplinaViewModel disciplinaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _disciplinaService.Adicionar(_mapper.Map<Disciplina>(disciplinaViewModel));

            return CustomResponse(disciplinaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, DisciplinaViewModel disciplinaViewModel)
        {
            if (id != disciplinaViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var disciplinaAtualizacao = await ObterDisciplina(id);

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            disciplinaAtualizacao.Nome = disciplinaViewModel.Nome;

            await _disciplinaService.Atualizar(_mapper.Map<Disciplina>(disciplinaAtualizacao));

            return CustomResponse(disciplinaViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DisciplinaViewModel>> Excluir(Guid id)
        {
            var disciplina = await ObterDisciplina(id);

            if (disciplina == null) return NotFound();

            await _disciplinaService.Remover(id);

            return CustomResponse(disciplina);
        }

        private async Task<DisciplinaViewModel> ObterDisciplina(Guid id)
        {
            return _mapper.Map<DisciplinaViewModel>(await _disciplinaRepository.ObterPorId(id));
        }

    }
}
