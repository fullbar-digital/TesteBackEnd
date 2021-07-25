using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student.manager.webapi.Services
{
    public class StudentService : IStudentService
    {
        private readonly DatabaseContext _context;

        public StudentService(DatabaseContext ctx)
        {
            _context = ctx;
        }
        public async Task<Student> Create(Student student)
        {
            if (student.AcademicRecord.IsNullOrEmpty())
                throw new BadRequestException("O RA não está preenchido!");
            if(student.CourseId <= 0)
                throw new BadRequestException("O ID do curso deve ser maior que zero!");

            if(! await _context.Courses.AnyAsync(c => c.CourseId == student.CourseId))
                throw new BadRequestException(string.Format("Não foi possível encontrar um curso com o ID {0}!", student.CourseId));

            /* Verify if student exists */
            var studentExists =
                await _context.Students.AsQueryable().AnyAsync(c => c.AcademicRecord.ToLower() == student.AcademicRecord.ToLower());
            if (studentExists)
                throw new BadRequestException("Um estudante com este mesmo RA já existe no sistema!");

            await _context.Students.AddAsync(student);
            _context.SaveChanges();

            return await Find(student.AcademicRecord);
        }

        public async Task<bool> Delete(string academicRecord)
        {
            Student student = await Find(academicRecord);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Student> Find(string academicRecord)
        {
            if (academicRecord.IsNullOrEmpty())
                throw new BadRequestException("O RA não está preenchido!");

            Student student =
                await _context.Students
                    .Include(s => s.Course)
                    .Include(s => s.Grades)
                    .FirstAsync(s => s.AcademicRecord.ToLower() == academicRecord.ToLower());
            if (student.IsNull())
                throw new NotFoundException("Estudante não encontrado");

            return student;
        }

        public async Task<IEnumerable<Student>> FindAny(string academicRecord = "", string name = "", long courseId = 0, string status = "")
        {
            if (academicRecord.IsNullOrEmpty() && name.IsNullOrEmpty() && courseId == 0 &&
                status.IsNullOrEmpty())
                throw new BadRequestException("Nenhum dos parâmetros da consulta foi informado!");

            return await _context.Students
                .AsQueryable()
                .Where(st => st.AcademicRecord.ToLower().Contains(academicRecord.ToLower())
                             || st.Name.ToLower().Contains(name.ToLower())
                             || st.Status.ToLower() == status.ToLower()
                             || st.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<bool> Update(Student student)
        {
            Student createdStudent = await Find(student.AcademicRecord);

            createdStudent.Name = student.Name;
            createdStudent.Period = student.Period;
            createdStudent.Picture = student.Picture;
            createdStudent.CourseId = student.CourseId;

            _context.Entry(createdStudent).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
