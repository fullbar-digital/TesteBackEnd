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
    public class StudentSubjectRep : BaseRep<StudentSubject>, IStudentSubjectRep
    {
        private readonly Context.Context _context;

        public StudentSubjectRep(Context.Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<StudentSubject>> ListSubjects(int codestudent)
        {
            var lista = await _context.StudentSubject.Where(
                    x => x.StudentId == codestudent
                ).AsNoTracking().ToListAsync();

            return lista;
        }

        public async Task<StudentSubject> ListForStudentSubject(int codestudent, int codesubject)
        {
            var lista = await _context.StudentSubject.Where(
                    x => x.StudentId == codestudent && x.SubjectId == codesubject
                ).AsNoTracking().ToListAsync();

            return lista.FirstOrDefault();
        }
        public async Task<List<StudentSubject>> ListStudentForStatus(string status)
        {
            var lista = await _context.StudentSubject.Where(
                    x => x.Status == status
                ).AsNoTracking().ToListAsync();

            return lista;
        }
    }
}
