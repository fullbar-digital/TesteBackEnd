using Fullbar.Entities.Models.Courses;
using Fullbar.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fullbar.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly ICourseRepository _repository;
		public CourseController(ICourseRepository repository)
		{
			_repository = repository;
		}

		// GET: api/<CourseController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var courses = await _repository.GetAll();
				
				return Ok(courses);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// GET api/<CourseController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var courses = await _repository.GetById(id);

				return Ok(courses);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// POST api/<CourseController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Course course)
		{
			try
			{
				await _repository.Create(course);

				return Ok(course);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		// PUT api/<CourseController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CourseController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
