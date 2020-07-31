using System.Threading.Tasks;
using Api.Models;
using ApplicationCore.Domain.Repositories;
using Hisoka;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    ///     Controller de Aluno
    /// </summary>
    [Route("api/alunos")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /// <summary>
        ///     Contrutor
        /// </summary>
        /// <param name="studentService"></param>
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        ///     Endpoint responsável por listar os usuários
        /// </summary>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> All(ResourceQueryFilter filter)
        {
            var studentDb = await _studentService.All(filter);

            return Ok(studentDb);
        }

        /// <summary>
        ///     Endpoint responsável por recuperar o usuário pelo Id
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var studentDb = await _studentService.FindDto(id);

            return Ok(studentDb);
        }

        /// <summary>
        ///     Endpoint responsável por criar ou editar um usuário
        /// </summary>
        /// <param name="model">usuário a ser criado ou editado</param>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] StudentRequest model)
        {
            await _studentService.Save(model.ToObject());

            return Ok(new {Message = "Usuário cadastrado com sucesso!"});
        }

        /// <summary>
        ///     Endpoint responsável por criar ou editar um usuário
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <param name="model">usuário a ser criado ou editado</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StudentRequest model)
        {
            var student = model.ToObject(id);
            await _studentService.Update(student);

            return Ok(new
                {Status = student.Status ? "Aprovado" : "Reprovado", Message = "Usuário alterado com sucesso!"});
        }

        /// <summary>
        ///     Endpoint responsável por recuperar o usuário pelo Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.Delete(id);

            return Ok(new {Message = "Usuário deletado com sucesso!"});
        }
    }
}