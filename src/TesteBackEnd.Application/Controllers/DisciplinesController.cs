using Microsoft.AspNetCore.Mvc;
using TesteBackEnd.Domain.Dtos.Discipline;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class DisciplinesController : MainController
    {
        protected readonly IDisciplineService _service;
        public DisciplinesController(IDisciplineService service, INotifier notifier) : base(notifier)
        {
            _service = service;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisciplineDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DisciplineDto>> Get(Guid id)
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
        /// Creates a single user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ActionResult<DisciplineDtoCreateResult>> Post([FromBody] DisciplineDtoCreate entity)
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

        public async Task<ActionResult<DisciplineDtoUpdateResult>> Put([FromRoute] Guid id, [FromBody] DisciplineDtoUpdate dto)
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
