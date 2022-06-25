using Microsoft.AspNetCore.Mvc;

namespace Teste.WebAPI.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult<T> CreateResponse<T>(Task<T> method)
        {
            try
            {
                return Ok(method.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessage { Descricao = "Operação não realizada", Mensagem = ex.Message});
            }            
        }        
    }

    internal class ErrorMessage
    {
        public string Descricao { get; set; } = default!;
        public string Mensagem { get; set; } = default!;
    }
}
