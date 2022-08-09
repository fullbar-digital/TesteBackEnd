using Microsoft.AspNetCore.Mvc;
using TesteBackEnd.Domain.Dtos.Score;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class StudentsController : MainController
    {
        protected readonly IStudentService _service;
        protected readonly IScoreService _scoreService;
        public StudentsController(IStudentService service, INotifier notifier, IScoreService scoreService) : base(notifier)
        {
            _service = service;
            _scoreService = scoreService;
        }

        /// <summary>
        /// Select a list of students
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("Filter")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Filter([FromBody] StudentDtoFilter filter)
        {
            try
            {
                var result = await _service.FilterAsync(r =>
                    (string.IsNullOrEmpty(filter.Name) ||
                    (!string.IsNullOrEmpty(filter.Name) && r.Name.ToLower().Contains(filter.Name.ToLower()))) &&

                    (string.IsNullOrEmpty(filter.CourseName) ||
                    (!string.IsNullOrEmpty(filter.CourseName) && r.Course.Name.ToLower().Contains(filter.CourseName.ToLower()))) &&

                    (string.IsNullOrEmpty(filter.AcademicRecord) ||
                    (!string.IsNullOrEmpty(filter.AcademicRecord) && r.AcademicRecord.ToLower().Contains(filter.AcademicRecord.ToLower())))

                    && (r.Status == filter.Status)
                );

                if (result != null && result.Count() > 0)
                    return CustomResponse(result);
                return NoContent();
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Select all students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _service.SelectAsync();
                if (result != null && result.Count() > 0)
                    return CustomResponse(result);
                return NoContent();
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }
        /// <summary>
        /// Select a single user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDto>> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _service.SelectAsync(id);
                if (result != null)
                    return CustomResponse(result);
                return NotFound();

            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        /// <summary>
        /// Creates a single Student
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ActionResult<StudentDtoCreateResult>> Post([FromBody] StudentDtoCreate entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.InsertAsync(entity);
                if (result != null)
                    return Created(nameof(Get), result);
                else
                {
                    return CustomResponse();
                }
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

        [HttpPost]
        [Route("Scores")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        /// <summary>
        /// Creates a Score for a single Student
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ActionResult<StudentDtoCreateResult>> Post([FromBody] ScoreDtoCreate entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _scoreService.InsertAsync(entity);
                if (result != null)
                    return Created(nameof(Get), result);
                else
                {
                    return CustomResponse();
                }
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Updates a single student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<StudentDtoUpdateResult>> Put([FromRoute] Guid id, [FromBody] StudentDtoUpdate dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var exists = await _service.ExistAsync(id);
                if (!exists)
                    return NotFound();


                await _service.UpdateAsync(id, dto);
                return Accepted();
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Removes a single student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var exists = await _service.ExistAsync(id);
                if (!exists)
                    return NotFound();
                return CustomResponse(await _service.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

    }
}
