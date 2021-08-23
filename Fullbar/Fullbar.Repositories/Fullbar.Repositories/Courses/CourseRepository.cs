using Fullbar.Entities.Models.Courses;
using Fullbar.Entities.Persistences;
using Fullbar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Courses
{
	public class CourseRepository : ICourseRepository
	{
		private readonly FullbarDBContext _context;

		public CourseRepository(FullbarDBContext context)
		{
			_context = context;
		}

		public async Task<Course> Create(Course course)
		{
			
			await _context.Course.AddAsync(course);
			await _context.SaveChangesAsync();

			return course;
		}

		public void Delete(Course course)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Course>> GetAll()
		{
			return await _context.Course
				.Include(c => c.Disciplines).ToListAsync();
		}

		public async Task<Course> GetById(long id)
		{
			return await _context.Course
				.Include(c => c.Disciplines)
				.Where( c => c.CourseID == id)
				.FirstOrDefaultAsync();
		}

		public Task<Course> Update(Course course)
		{
			throw new NotImplementedException();
		}
	}
}
