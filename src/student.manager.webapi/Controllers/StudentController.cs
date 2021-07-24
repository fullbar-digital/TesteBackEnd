using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;

namespace student.manager.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("{academicRecord}")]
        public async Task<ActionResult<Student>> Find(string academicRecord)
        {
            var student = await _service.Find(academicRecord);

            return student.IsNull() ? NotFound() : student;
        }
        
        [HttpGet("{academicRecord}/{name}/{courseId}/{status}")]
        public async Task<ActionResult<IEnumerable<Student>>> FindAny(string academicRecord, string name, long courseId, string status)
        {
            var students = await _service.FindAny(academicRecord, name, courseId, status);

            return students.ToList();
        }

        [HttpPost()]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            var createdStudent = await _service.Create(student);

            return createdStudent;
        }

        
        [HttpDelete("{academicRecord}")]
        public async Task<ActionResult> Delete(string academicRecord)
        {
            var studentDeleted = await _service.Delete(academicRecord);

            return studentDeleted ? Ok() : BadRequest();
        }
        
        [HttpPut("{academicRecord}")]
        public async Task<ActionResult> Update(string academicRecord, Student student)
        {
            student.AcademicRecord = academicRecord;

            var studentUpdated = await _service.Update(student);

            return studentUpdated ? NoContent() : BadRequest();
        }
    }
}
