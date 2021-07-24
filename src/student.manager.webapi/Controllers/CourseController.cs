using course.manager.webapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Models;
using System;
using System.Threading.Tasks;

namespace course.manager.webapi.Controllers
{
    /// <summary>
    /// Controller de cursos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        /// <summary>
        /// Controller de cursos
        /// </summary>
        /// <param name="service"></param>
        public CourseController(ICourseService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Find(long id)
        {
            try
            {
                var course = await _service.Find(id);

                return course.IsNull() ? NotFound() : course;
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.Message);
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<Course>> Create(Course course)
        {
            try
            {
                var createdCourse = await _service.Create(course);

                return createdCourse;
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.Message);
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var courseDeleted = await _service.Delete(id);

                return courseDeleted ? Ok() : BadRequest();
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.Message);
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, Course course)
        {
            try
            {
                course.CourseId = id;

                var courseUpdated = await _service.Update(course);

                return courseUpdated ? NoContent() : BadRequest();
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.Message);
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Problem(e.Message);
            }
        }
    }
}
