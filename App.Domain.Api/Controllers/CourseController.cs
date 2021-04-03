using System;
using System.Threading.Tasks;
using App.Domain.Commands;
using App.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace App.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/course")]
    public class CourseController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostCourse([FromBody] CreateCourseCommand command,
                                             [FromServices] CreateCourseHandler handler)
        {
            var result = (CommandResult)handler.handle(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }

}