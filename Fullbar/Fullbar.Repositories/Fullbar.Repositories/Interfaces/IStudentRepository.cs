using Fullbar.Entities.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Interfaces
{
	public interface IStudentRepository
	{
		Task<Student> Create(Student student);
		Task<Student> Update(Student student);
		Task Delete(Student student);
		Task<Student> GetById(long id);
		Task<IEnumerable<Student>> GetAll();
		Task<IList<Student>> FindByCondition(Expression<Func<Student, bool>> expression);
 	}
}
