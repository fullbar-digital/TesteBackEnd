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
    public class CourseSubjectRep : BaseRep<CourseSubject>, ICourseSubjectRep
    {
        private readonly Context.Context _context;

        public CourseSubjectRep(Context.Context context) : base(context)
        {
            _context = context;
        }
        public async Task<CourseSubject> CourseForSubject(CourseSubject coursesubject)
        {
            var item = await _context.CourseSubject
                .Where(x => x.CourseId == coursesubject.CourseId
                && x.SubjectId == coursesubject.SubjectId)
                .AsNoTracking()
                .ToListAsync();

            return item.FirstOrDefault();
        }

        public async Task<List<CourseSubject>> ForCourse(int codecourse)
        {
            var item = await _context.CourseSubject
                .Where(x => x.CourseId == codecourse)
                .AsNoTracking()
                .ToListAsync();

            return item;
        }

        public async Task<List<CourseSubject>> ForSubject(int subjectcode)
        {
            var item = await _context.CourseSubject
                .Where(x => x.SubjectId == subjectcode)
                .AsNoTracking()
                .ToListAsync();

            return item;
        }
    }
}
