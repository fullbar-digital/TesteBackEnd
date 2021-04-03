using System;
using System.Threading.Tasks;
using App.Domain.Commands;
using App.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace App.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/student")]
    public class StudentsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateStudentCommand command,
                                             [FromServices] CreateStudentHandler handler)
        {
            var result = (CommandResult)handler.handle(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] GetAllStudentsHandler handler)
        {
            var result = (CommandResult)handler.handle();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> Delete([FromServices] DeleteStudentsHandler handler, 
                                               [FromRoute] DeleteStudentCommand command)
        {
            var result = (CommandResult)handler.handle(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<ActionResult> Update([FromServices] UpdateStudentHandler handler, 
                                               [FromRoute] Guid Id,
                                               [FromBody] UpdateStudentrCommand command)
        {   

            command.Id = Id;

            var result = (CommandResult)handler.handle(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("filters")]
        public async Task<ActionResult> GetByFilters([FromQuery] GetStudentsQuery query, 
                                                     [FromServices] GetStudentsByFilterHandler handler)
        {   
            var result = (CommandResult)handler.handle(query);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }

}