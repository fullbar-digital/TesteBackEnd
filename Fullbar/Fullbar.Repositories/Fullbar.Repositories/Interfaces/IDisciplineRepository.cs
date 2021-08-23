using Fullbar.Entities.Models.Disciplines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Interfaces
{
	public interface IDisciplineRepository
	{
		Task<Discipline> Create(Discipline discipline);
		Task<Discipline> Update(Discipline discipline);
		void Delete(Discipline discipline);
		Task<Discipline> GetById(long id);
		Task<IEnumerable<Discipline>> GetAll();
	}
}
