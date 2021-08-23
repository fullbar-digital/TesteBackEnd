using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Persistences;
using Fullbar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Disciplines
{
	public class DisciplineRepository : IDisciplineRepository
	{
		private readonly FullbarDBContext _context;

		public DisciplineRepository(FullbarDBContext context)
		{
			_context = context;
		}

		public async Task<Discipline> Create(Discipline discipline)
		{
			var course = await _context.Course.Where(c => c.CourseID == discipline.CourseId).FirstAsync();

			discipline.Course = course;

			await _context.Discipline.AddAsync(discipline);

			await _context.SaveChangesAsync();

			return discipline;
		}

		public void Delete(Discipline discipline)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Discipline>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Discipline> GetById(long id)
		{
			throw new NotImplementedException();
		}

		public Task<Discipline> Update(Discipline discipline)
		{
			throw new NotImplementedException();
		}
	}
}
