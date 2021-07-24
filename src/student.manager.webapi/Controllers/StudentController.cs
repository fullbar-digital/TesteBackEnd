﻿using Microsoft.AspNetCore.Mvc;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student.manager.webapi.Controllers
{
    /// <summary>
    /// Ações dos estudantes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        /// <summary>
        /// Ações do estudantes
        /// </summary>
        /// <param name="service"></param>
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="academicRecord"></param>
        /// <returns></returns>
        [HttpGet("{academicRecord}")]
        public async Task<ActionResult<Student>> Find(string academicRecord)
        {
            try
            {
                var student = await _service.Find(academicRecord);

                return student.IsNull() ? NotFound() : student;
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
        /// <param name="academicRecord"></param>
        /// <param name="name"></param>
        /// <param name="courseId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("{academicRecord}/{name}/{courseId}/{status}")]
        public async Task<ActionResult<IEnumerable<Student>>> FindAny(string academicRecord, string name, long courseId, string status)
        {
            try
            {
                var students = await _service.FindAny(academicRecord, name, courseId, status);

                return students.ToList();
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
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            try
            {
                var createdStudent = await _service.Create(student);

                return createdStudent;
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
        /// <param name="academicRecord"></param>
        /// <returns></returns>
        [HttpDelete("{academicRecord}")]
        public async Task<ActionResult> Delete(string academicRecord)
        {
            try
            {
                var studentDeleted = await _service.Delete(academicRecord);

                return studentDeleted ? Ok() : BadRequest();
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
        /// <param name="academicRecord"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{academicRecord}")]
        public async Task<ActionResult> Update(string academicRecord, Student student)
        {
            try
            {
                student.AcademicRecord = academicRecord;

                var studentUpdated = await _service.Update(student);

                return studentUpdated ? NoContent() : BadRequest();
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
