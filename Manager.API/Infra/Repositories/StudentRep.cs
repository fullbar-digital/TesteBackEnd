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
    public class StudentRep : BaseRep<Student>, IStudentRep
    {
        private readonly Context.Context _context;

        public StudentRep(Context.Context context) : base(context)
        {
            this._context = context;
        }
        public async Task<List<Student>> StudentForName(string nome)
        {
            var lista = await _context.Student.Where(
                    x => x.Name.ToLower() == nome.ToLower()
                ).AsNoTracking().ToListAsync();

            return lista;
        }

        public async Task<Student> StudentForRa(string ra)
        {
            var lista = await _context.Student.Where(
                    x => x.RA.ToLower() == ra.ToLower()
                ).AsNoTracking().ToListAsync();

            return lista.FirstOrDefault();
        }

        public async Task<List<Student>> StudentForCourse(int code)
        {
            var lista = await _context.Student.Where(
                    x => x.CodeCourse == code
                ).AsNoTracking().ToListAsync();

            return lista;
        }
    }
}
