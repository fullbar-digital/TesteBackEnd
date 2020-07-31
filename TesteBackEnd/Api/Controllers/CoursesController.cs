using System.Threading.Tasks;
using ApplicationCore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    ///     Controller de Cursos
    /// </summary>
    [Route("api/cursos")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        /// <summary>
        ///     Contrutor
        /// </summary>
        /// <param name="courseService"></param>
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        ///     Endpoint responsável por listar os cursos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var courseDb = await _courseService.All();

            return Ok(courseDb);
        }
    }
}