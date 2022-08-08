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

        [HttpGet("{filter}")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> Find(string filter)
        {
            try
            {
                var modelSearch = await _service.SelectAsync(r =>
                    (string.IsNullOrEmpty(filter) ||
                    (!string.IsNullOrEmpty(filter) && r.Name.ToLower().Contains(filter.ToLower()))) &&

                     (string.IsNullOrEmpty(filter) ||
                    (!string.IsNullOrEmpty(filter) && r.AcademicRecord.ToLower().Contains(filter.ToLower()))) &&

                     (string.IsNullOrEmpty(filter) ||
                    (!string.IsNullOrEmpty(filter) && r.CouserId.ToLower().Contains(filter.ToLower()))) &&

                     (string.IsNullOrEmpty(filter) ||
                    (!string.IsNullOrEmpty(filter) && r.Status.ToString().ToLower().Contains(filter.ToLower())))
                );


                return CustomResponse(modelSearch);
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }


        /// <summary>
        /// Select all users
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
        /// Updates a single user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
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
                var entityToUpdate = await _service.SelectAsync(id);
                if (entityToUpdate == null)
                    return NotFound();


                dto.Id = entityToUpdate.Id;
                await _service.UpdateAsync(dto);
                return Accepted();
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

        /// <summary>
        /// Removes a single user
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
                var entityToDelete = await _service.SelectAsync(id);
                if (entityToDelete == null)
                    return NotFound();

                await _service.DeleteAsync(id);
                return CustomResponse();
            }
            catch (Exception ex)
            {
                ErrorNotifier(ex.Message);
                return CustomResponse();
            }
        }

    }
}
