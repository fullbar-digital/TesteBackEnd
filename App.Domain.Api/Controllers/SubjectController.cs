using System;
using System.Threading.Tasks;
using App.Domain.Commands;
using App.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace App.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/subject")]
    public class SubjectController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostSubject([FromBody] CreateSubjectCommand command,
                                             [FromServices] CreateSubjectHandler handler)
        {
            var result = (CommandResult)handler.handle(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }

}