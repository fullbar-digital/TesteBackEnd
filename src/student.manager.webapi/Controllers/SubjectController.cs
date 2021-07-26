using Microsoft.AspNetCore.Mvc;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace subject.manager.webapi.Controllers
{
    /// <summary>
    /// Controller de cursos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;

        /// <summary>
        /// Controller de cursos
        /// </summary>
        /// <param name="service"></param>
        public SubjectController(ISubjectService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> Find(long id)
        {
            try
            {
                var subject = await _service.Find(id);

                return Ok(subject);
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return NotFound(e.InnerException?.Message ?? e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<Subject>> Create(Subject subject)
        {
            try
            {
                var createdSubject = await _service.Create(subject);

                return Ok(createdSubject);
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return NotFound(e.InnerException?.Message ?? e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjects"></param>
        /// <returns></returns>
        [HttpPost("createMany")]
        public async Task<ActionResult<IEnumerable<Subject>>> CreateMany(List<Subject> subjects)
        {
            try
            {
                var createdSubjects = await _service.CreateMany(subjects);

                return Ok(createdSubjects);
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return NotFound(e.InnerException?.Message ?? e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message);
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
                var subjectDeleted = await _service.Delete(id);

                return subjectDeleted ? Ok() : BadRequest();
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return NotFound(e.InnerException?.Message ?? e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, Subject subject)
        {
            try
            {
                subject.SubjectId = id;

                var subjectUpdated = await _service.Update(subject);

                return subjectUpdated ? NoContent() : BadRequest();
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return NotFound(e.InnerException?.Message ?? e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                return Problem(e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
