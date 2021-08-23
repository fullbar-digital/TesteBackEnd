using Fullbar.Entities.Models.Disciplines;
using Fullbar.Entities.Models.Students;
using Fullbar.Entities.Persistences;
using Fullbar.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Students
{
	public class StudentRepository : IStudentRepository
	{
		private readonly FullbarDBContext _context;

		public StudentRepository(FullbarDBContext context)
		{
			_context = context;
		}

		public async Task<IList<Student>> FindByCondition(Expression<Func<Student, bool>> expression)
		{
			var students = await _context.Student
							.Include( s => s.Course )
							.ThenInclude( d => d.Disciplines )
							.Where(expression)
							.ToListAsync();

			foreach (var s in students)
			{
				foreach (var d in s.Course.Disciplines)
				{
					var grade = await _context.Grade
										.Where(g => g.StudentID == s.Id && g.DisciplineID == d.DisciplineID)
										.FirstOrDefaultAsync();

					d.Grades = new List<Grade>();
					if (grade != null)
					{
						d.Grades.Add(grade);
					}
				}
			}

			return students;
		}

		public async Task<Student> Create(Student student)
		{
			var course = await _context.Course.Where(c => c.CourseID == student.CourseId).FirstAsync();

			student.Course = course;

			var studentData = await _context.Student.AddAsync(student);

			await _context.SaveChangesAsync();

			return student;
		}
		public async Task Delete(Student student)
		{
			_context.Student.Remove(student);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Student>> GetAll()
		{
			var students = await _context.Student
				.Include(c => c.Course)
				.ThenInclude(d => d.Disciplines)
				.ToListAsync();

			foreach (var s in students)
			{
				foreach (var d in s.Course.Disciplines)
				{
					var grade = await _context.Grade
										.Where(g => g.StudentID == s.Id && g.DisciplineID == d.DisciplineID)
										.FirstOrDefaultAsync();

					d.Grades = new List<Grade>();
					if (grade != null)
					{
						d.Grades.Add(grade);
					}
				}
			}

			return students;
		}

		public async Task<Student> GetById(long id)
		{
			var student = await _context.Student
									.Include(c => c.Course)
									.ThenInclude(d => d.Disciplines)
									.Where(std => std.Id == id)
									.FirstOrDefaultAsync();

			if (student == null)
			{
				return student;
			}

			foreach (var d in student.Course.Disciplines)
			{
				var grade = await _context.Grade
									.Where(g => g.StudentID == student.Id && g.DisciplineID == d.DisciplineID)
									.FirstOrDefaultAsync();

				d.Grades = new List<Grade>();
				if (grade != null)
				{
					d.Grades.Add(grade);
				}
			}

			return student;
		}

		public async Task<Student> Update(Student student)
		{
			var studentData = await _context.Student
				.Include(s => s.Course)
				.Where(s => s.Id == student.Id)
				.FirstOrDefaultAsync();

			studentData.Name = student.Name;
			studentData.RA = student.RA;
			studentData.Period = student.Period;
			studentData.Picture = student.Picture;
			studentData.Course = await _context.Course.Where( c=> c.CourseID == student.CourseId).FirstOrDefaultAsync();

			await _context.SaveChangesAsync();
			
			return studentData;
		}
	}
}
