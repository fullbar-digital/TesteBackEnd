using Cadastro.web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cadastro.web.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService ?? throw new ArgumentNullException(nameof(alunoService));
        }

        public async Task<IActionResult> AlunosIndex()
        {
            var alunos = await _alunoService.FindAll();
            return View(alunos);
        }
    }
}
