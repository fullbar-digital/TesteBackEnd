using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using grade.manager.webapi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Models;

namespace student.manager.webapi.Services
{
    public class GradeService : IGradeService
    {
        private readonly DatabaseContext _context;

        public GradeService(DatabaseContext ctx)
        {
            _context = ctx;
        }

        public async Task<Grade> Create(Grade grade)
        {
            if (grade.GradeId != 0)
                throw new BadHttpRequestException("Um novo registro não pode conter um ID diferente de zero!");
            
            await _context.Grades.AddAsync(grade);
            _context.SaveChanges();

            return await _context.Grades.LastOrDefaultAsync();
        }

        public async Task<bool> Delete(long gradeId)
        {
            if(gradeId <= 0)
                throw new BadHttpRequestException("Informe um número maior que zero!");

            Grade grade =
                await _context.Grades.FindAsync(gradeId);

            if (grade.IsNull())
                throw new NotFoundException("Nota não encontrada!");

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Grade> Find(long gradeId)
        {
            if(gradeId <= 0)
                throw new BadHttpRequestException("Informe um número maior que zero!");

            Grade grade =
                await _context.Grades.FindAsync(gradeId);

            if (grade.IsNull())
                throw new NotFoundException("Nota não encontrada!");

            return grade;
        }

        public async Task<bool> Update(Grade grade)
        {
            if(grade.GradeId <= 0)
                throw new BadHttpRequestException("Informe um número maior que zero!");

            Grade createdGrade =
                await _context.Grades.FindAsync(grade.GradeId);

            if (createdGrade.IsNull())
                throw new NotFoundException("Nota não encontrada, portanto não pode ser atualizada!");
            
            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
