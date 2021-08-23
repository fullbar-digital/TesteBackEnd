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
	public class DisciplineController : ControllerBase
	{
		private readonly IDisciplineRepository _repository;

		public DisciplineController(IDisciplineRepository repository)
		{
			_repository = repository;
		}

		// GET: api/<DisciplineController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<DisciplineController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<DisciplineController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Discipline discipline)
		{
			try
			{
				 await _repository.Create(discipline);

				return Ok(discipline);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// PUT api/<DisciplineController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<DisciplineController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
