using Fullbar.Entities.Models.Courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Interfaces
{
	public interface ICourseRepository
	{
		Task<Course> Create(Course course);
		Task<Course> Update(Course course);
		void Delete(Course course);
		Task<Course> GetById(long id);
		Task<IEnumerable<Course>> GetAll();
	}
}
