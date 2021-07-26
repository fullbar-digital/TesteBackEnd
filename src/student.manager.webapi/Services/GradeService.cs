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
                throw new BadRequestException("Um novo registro não pode conter um ID diferente de zero.");

            BadRequestException.ThrowIfNotEmpty(await VerifyInstanceData(grade));

            await _context.Grades.AddAsync(grade);
            _context.SaveChanges();

            return grade;
        }

        public async Task<bool> Delete(long gradeId)
        {            
            Grade grade = await Find(gradeId);

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Grade> Find(long gradeId)
        {
            if (gradeId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Grade grade =
                await _context.Grades.FindAsync(gradeId);

            if (grade.IsNull())
                throw new NotFoundException("Nota não encontrada!");

            return grade;
        }

        public async Task<bool> Update(Grade grade)
        {
            BadRequestException.ThrowIfNotEmpty(await VerifyInstanceData(grade));

            Grade createdGrade = await Find(grade.GradeId);

            createdGrade.AcademicRecord = grade.AcademicRecord;
            createdGrade.SubjectId = grade.SubjectId;
            createdGrade.Value = grade.Value;

            _context.Entry(createdGrade).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string> VerifyInstanceData(Grade grade)
        {
            string errorMessage = "";

            if (grade.AcademicRecord.IsNullOrEmpty())
                errorMessage += "O RA não está preenchido./n";
            else if (await _context.Students.AnyAsync() && !await _context.Students.AnyAsync(s => s.AcademicRecord.ToLower() == grade.AcademicRecord.ToLower()))
                errorMessage += string.Format("Não foi possível encontrar um aluno com o RA {0}./n", grade.AcademicRecord);

            if (grade.SubjectId <= 0)
                errorMessage += "O ID da matéria deve ser maior que zero./n";
            else if (await _context.Subjects.AnyAsync() && !await _context.Subjects.AnyAsync(s => s.SubjectId == grade.SubjectId))
                errorMessage += string.Format("Não foi possível encontrar uma matéria com o ID {0}./n", grade.SubjectId);

            if (grade.Value < 0)
                errorMessage += "O valor da nota deve ser maior ou igual a zero./n";

            return errorMessage;
        }
    }
}
