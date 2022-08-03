using Domain.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CourseRep : BaseRep<Course>, ICourseRep
    {
        private readonly Context.Context _context;

        public CourseRep(Context.Context context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Course>> CourseForName(string name)
        {
            var lista = await _context.Course.Where(
                    x => x.Name == name
                ).AsNoTracking().ToListAsync();

            return lista;
        }
    }
}
