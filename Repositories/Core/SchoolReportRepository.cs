using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Entities;


namespace Repositories.Core
{
    public class SchoolReportRepository : DefaultRepository<SchoolReport>
    {
        public SchoolReportRepository(EfDbContext context) : base(context) { }

        public void AddOrUpdateReport(Guid studentId, Guid subjectId, decimal grade)
        {
            var exists = _context.SchoolReport.FirstOrDefault(a =>
                a.StudentId.Equals(studentId) && a.SubjectId.Equals(subjectId));
            if (exists != null && exists.Grade != grade)
            {
                exists.Grade = grade;
                _context.Entry(exists).State = EntityState.Modified;
            }

            if(exists == null)
            {
                _context.SchoolReport.Add(new SchoolReport()
                {
                    StudentId = studentId,
                    SubjectId = subjectId,
                    Grade = grade
                });
            }
            _context.SaveChanges();
        }

    }
}
