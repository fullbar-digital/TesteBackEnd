using AutoMapper;
using Fullbar.Teste.Api.Controllers;
using Fullbar.Teste.Api.ViewModels;
using Fullbar.Teste.Application.Interfaces;
using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Fullbar.Teste.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/alunos")]
    public class AlunosController : MainController
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoService _alunoService;
        private readonly IMapper _mapper;

        public AlunosController(INotificador notificador,
                                  IAlunoRepository alunoRepository,
                                  IAlunoService alunoService,
                                  IMapper mapper) : base(notificador)
        {
            _alunoRepository = alunoRepository;
            _alunoService = alunoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AlunoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AlunoViewModel>>(await _alunoRepository.ObterAlunosCursoDisciplinas());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> ObterPorId(Guid id)
        {
            var alunoViewModel = await ObterAluno(id);

            if (alunoViewModel == null) return NotFound();

            return alunoViewModel;
        }

        [HttpGet("obter")]
        public async Task<ActionResult<AlunoViewModel>> Obter([FromBody] AlunoViewModel alunoViewModel)
        {
            var response = _mapper.Map<AlunoViewModel>(await _alunoService.Obter(_mapper.Map<Aluno>(alunoViewModel)));

            if (response == null) return NotFound();

            return CustomResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult<AlunoViewModel>> Adicionar(AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + alunoViewModel.Foto;
            if (!UploadArquivo(alunoViewModel.FotoUpload, imagemNome))
            {
                return CustomResponse(alunoViewModel);
            }

            alunoViewModel.Foto = imagemNome;
            await _alunoService.Adicionar(_mapper.Map<Aluno>(alunoViewModel));

            return CustomResponse(alunoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, AlunoViewModel alunoViewModel)
        {
            if (id != alunoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var alunoAtualizacao = await ObterAluno(id);

            if (string.IsNullOrEmpty(alunoViewModel.Foto))
                alunoViewModel.Foto = alunoAtualizacao.Foto;

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (alunoViewModel.FotoUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + alunoViewModel.Foto;
                if (!UploadArquivo(alunoViewModel.FotoUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }

                alunoAtualizacao.Foto = imagemNome;
            }

            alunoAtualizacao.CursoId = alunoViewModel.CursoId;
            alunoAtualizacao.Nome = alunoViewModel.Nome;
            alunoAtualizacao.RA = alunoViewModel.RA;
            alunoAtualizacao.Periodo = alunoViewModel.Periodo;

            await _alunoService.Atualizar(_mapper.Map<Aluno>(alunoAtualizacao));

            return CustomResponse(alunoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AlunoViewModel>> Excluir(Guid id)
        {
            var aluno = await ObterAluno(id);

            if (aluno == null) return NotFound();

            await _alunoService.Remover(id);

            return CustomResponse(aluno);
        }

        private async Task<AlunoViewModel> ObterAluno(Guid id)
        {
            return _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterAlunoCursoDisciplinas(id));
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este aluno!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}