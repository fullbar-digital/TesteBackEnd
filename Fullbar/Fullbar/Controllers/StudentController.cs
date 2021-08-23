using Fullbar.Entities.Models.Students;
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
	public class StudentController : ControllerBase
	{
		private readonly IStudentRepository _repository;

		public StudentController(IStudentRepository repository)
		{
			_repository = repository;
		}

		// GET: api/<StudentController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var students = await _repository.GetAll();

				return Ok(students);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// GET api/<StudentController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var student = await _repository.GetById(id);
				if (student == null)
				{
					return NotFound(student);
				}
				return Ok(student);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("search")]
		public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] string ra, [FromQuery] string course)
		{
			try
			{
				var students = await _repository.FindByCondition(s => s.Name.Contains(name) || 
																	  s.RA == ra || 
																	  s.Course.Name.Contains(course));

				return Ok(students);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// POST api/<StudentController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Student student)
		{
			try
			{
				var students = await _repository.Create(student);

				return Ok(students);
			} 
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// PUT api/<StudentController>/5
		[HttpPut("{id}")]
		public  async Task<IActionResult> Put([FromRoute] long id, [FromBody] Student student)
		{
			try
			{
				if (student == null)
				{
					return NotFound();
				}

				student.Id = id;
				var s = await _repository.Update(student);

				return Ok(s);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// DELETE api/<StudentController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var student = await _repository.GetById(id);

				if (student == null)
				{
					return NotFound();
				}

				await _repository.Delete(student);

				return Ok(student);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
