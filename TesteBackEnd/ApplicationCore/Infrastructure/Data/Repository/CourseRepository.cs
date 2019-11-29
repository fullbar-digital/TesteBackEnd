using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Domain;
using ApplicationCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Infrastructure.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TesteBackEndContext _context;

        public CourseRepository(TesteBackEndContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Course>> All()
        {
            return await _context.Set<Course>()
                .Where(x => x.Active).ToListAsync();
        }
    }
}