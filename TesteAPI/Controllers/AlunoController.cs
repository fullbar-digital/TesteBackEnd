using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TesteAPI.MLL.ViewObject;

namespace TesteAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AlunoController : ControllerBase
    {

        private readonly BLL.Interfaces.IAlunoBLL _alunoBLL;

        public AlunoController(BLL.Interfaces.IAlunoBLL alunoBLL)
        {
            _alunoBLL = alunoBLL;
        }
       
        [HttpGet]
        [Produces("application/json")]
        public dynamic GetAll()
        {
            var retorno = _alunoBLL.GetAllAlunos();

            return Ok(retorno);
        }

        [HttpPost]
        public dynamic Create([FromBody]AlunoVO alunoVO)
        {
            try
            {
                _alunoBLL.CadastrarAluno(alunoVO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }            
        }

        [HttpPost]
        public dynamic Edit([FromBody] AlunoVO alunoVO)
        {
            try
            {
                _alunoBLL.AlterarAluno(alunoVO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public dynamic Delete([FromQuery]string ra)
        {
            try
            {
                _alunoBLL.DeletarAluno(ra);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public dynamic Filter([FromForm] MLL.ViewObject.FiltroVO filtro)
        {
            try
            {
                
                return _alunoBLL.GetAlunoPorCampo(filtro);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
