using Microsoft.AspNetCore.Mvc;
using TesteAPI.BLL.Interfaces;
using TesteAPI.MLL;
using TesteAPI.MLL.ViewObject;
using TesteAPI.DAL.Repositories.Interfaces;
using System.Linq;
using System;

namespace TesteAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AlunoNotaController : Controller
    {

        public IAlunoNotaBLL _notaBLL;
        public IUnitOfWork _uow;
        public AlunoNotaController(IAlunoNotaBLL notaBLL, IUnitOfWork uow)
        {
            _notaBLL = notaBLL;
            _uow = uow;
        }

        [HttpPost]
        public dynamic Create([FromBody] NotaCadastroVO notaVO)
        {
            try
            {
                _notaBLL.CadastrarNota(notaVO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }



    }
}
