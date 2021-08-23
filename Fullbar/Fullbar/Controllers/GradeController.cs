using Fullbar.Entities.Models.Disciplines;
using Fullbar.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fullbar.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradeController : ControllerBase
	{
		private readonly IGradeRepository _repository;

		public GradeController(IGradeRepository repository)
		{
			_repository = repository;
		}

		// GET: api/<GradeController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<GradeController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<GradeController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Grade grade)
		{
			try
			{
				var response = await _repository.Create(grade);

				return Ok();
			} 
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut()]
		public async Task<IActionResult> Put([FromBody] Grade grade)
		{
			try
			{
				var gradeData = await _repository.Update(grade);
				
				if (gradeData == null)
				{
					return NotFound();
				}

				return Ok(gradeData);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// DELETE api/<GradeController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
