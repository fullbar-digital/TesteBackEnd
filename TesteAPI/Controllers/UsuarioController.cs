using Microsoft.AspNetCore.Mvc;

namespace TesteAPI.Controllers
{    
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class UsuarioController : Controller
    {
        private readonly BLL.Interfaces.IUsuarioBLL _userBLL;
        public UsuarioController(BLL.Interfaces.IUsuarioBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpPost]
        [Route("login")]        
        public dynamic Logar([FromBody]MLL.ViewObject.UsuarioVO user)
        {
            return _userBLL.Logar(user);
        }
    }
}
