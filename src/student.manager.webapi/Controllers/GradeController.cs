using grade.manager.webapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Models;
using System;
using System.Threading.Tasks;

namespace grade.manager.webapi.Controllers
{
    /// <summary>
    /// Controller de Notas (boletim) dos estudantes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _service;

        /// <summary>
        /// Controller de Notas (boletim) dos estudantes
        /// </summary>
        /// <param name="service"></param>
        public GradeController(IGradeService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> Find(long id)
        {
            try
            {
                var grade = await _service.Find(id);

                return grade.IsNull() ? NotFound() : grade;
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
        /// <param name="grade"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<Grade>> Create(Grade grade)
        {
            try
            {
                var createdGrade = await _service.Create(grade);

                return createdGrade;
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
                var gradeDeleted = await _service.Delete(id);

                return gradeDeleted ? Ok() : BadRequest();
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
        /// <param name="grade"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, Grade grade)
        {
            try
            {
                grade.GradeId = id;

                var gradeUpdated = await _service.Update(grade);

                return gradeUpdated ? NoContent() : BadRequest();
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
