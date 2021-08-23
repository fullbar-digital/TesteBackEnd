using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Persistences;
using Fullbar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Grades
{
	public class GradeRepository : IGradeRepository
	{
		private readonly FullbarDBContext _context;

		public GradeRepository(FullbarDBContext context)
		{
			_context = context;
		}

		public async Task<Grade> Create(Grade grade)
		{
			await _context.Grade.AddAsync(grade);
			await _context.SaveChangesAsync();

			return grade;
		}

		public async Task<Grade> Update(Grade grade)
		{
			var gradeData = await _context.Grade
				.Where(s => s.StudentID == grade.StudentID && s.DisciplineID == grade.DisciplineID)
				.FirstOrDefaultAsync();

			if (gradeData == null)
			{
				return grade;
			}

			gradeData.StudantGrade = grade.StudantGrade;

			await _context.SaveChangesAsync();

			return gradeData;
		}
	}
}
