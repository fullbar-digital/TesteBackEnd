using Fullbar.Entities.Models.Disciplines;
using System.Threading.Tasks;

namespace Fullbar.Repositories.Interfaces
{
	public interface IGradeRepository
	{
		Task<Grade> Create(Grade grade);
		Task<Grade> Update(Grade grade);
	}
}
