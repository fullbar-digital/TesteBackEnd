using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TesteAPI.BLL.Interfaces;
using TesteAPI.MLL.ViewObject;
namespace TesteAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CursoController : ControllerBase
    {

        private ICursoBLL _cursoBLL;

        public CursoController(ICursoBLL cursoBLL)
        {
            _cursoBLL = cursoBLL;
        }       
      

        [HttpPost]
        public dynamic Create([FromBody]CursoVO cursoVO)
        {
            try
            {
                var nomeUser = User.Identity.Name;
                _cursoBLL.CadastrarCurso(cursoVO);

                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}
