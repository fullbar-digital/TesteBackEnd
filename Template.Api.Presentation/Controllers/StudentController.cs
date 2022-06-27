using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Dto;
using Template.Api.ApplicationCore.Entities;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/students")]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get a list of students
        /// </summary>
        /// <param name="studentFilter"></param>
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<Student>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentsAsync([FromQuery] StudentFilterDto studentFilter)
        {
            var result = await _unitOfWork.Students.FindAsync(x =>
                   (string.IsNullOrEmpty(studentFilter.Name) || x.Name.Contains(studentFilter.Name))
                && (string.IsNullOrEmpty(studentFilter.RA) || x.RA.Contains(studentFilter.RA))
                && (string.IsNullOrEmpty(studentFilter.CourseName) || x.CourseSubjectStudent.Any(x => x.CourseSubject.Course.Name.Contains(studentFilter.CourseName)))
                && (studentFilter.Status.HasValue ? x.Status.Equals(studentFilter.Status.Value) : true));

            return Ok(result);
        }

        /// <summary>
        /// Get a specific student by id
        /// </summary>
        /// <param name="id">Student Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Student), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            return Ok(await _unitOfWork.Students.GetByIdAsync(id));
        }

        /// <summary>
        /// Update a specific student
        /// </summary>
        /// <param name="id">Student Id</param>
        /// <param name="body">Student's data to update</param>
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] int id, [FromBody] StudentBase body)
        {
            await _unitOfWork.Students.UpdateAsync(new Student()
            {
                StudentId = id,
                Name = body.Name,
                RA = body.RA,
                Period = body.Period,
                Photo = body.Photo
            });

            return Created("", null);
        }

        /// <summary>
        /// Delete an specific student
        /// </summary>
        /// <param name="id">Student id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] int id)
        {
            var result = await _unitOfWork.Students.DeleteAsync(id);
            if (result == 0)
                return BadRequest("Student not found");

            return Created("", null);
        }
    }
}