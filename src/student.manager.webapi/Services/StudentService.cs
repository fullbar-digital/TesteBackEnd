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
            BadRequestException.ThrowIfNotEmpty(await VerifyInstanceData(student));

            /* Verify if student exists */
            var studentExists =
                await _context.Students.AsQueryable().AnyAsync(c => c.AcademicRecord.ToLower() == student.AcademicRecord.ToLower());
            if (studentExists)
                throw new BadRequestException("Um estudante com este mesmo RA já existe no sistema.");

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
                throw new BadRequestException("O RA não está preenchido.");

            Student student =
                await _context.Students
                    .Include(s => s.Course)
                        .ThenInclude(c => c.Subjects)
                    .Include(s => s.Grades)
                    .FirstOrDefaultAsync(s => s.AcademicRecord.ToLower() == academicRecord.ToLower());
            if (student.IsNull())
                throw new NotFoundException("Estudante não encontrado");

            return student;
        }

        public async Task<IEnumerable<Student>> FindAny(string academicRecord = "", string name = "", long courseId = 0, string status = "")
        {
            List<Student> students = new List<Student>();
            if (!academicRecord.IsNullOrEmpty())
            {
                academicRecord = academicRecord == "null" ? "" : academicRecord.ToLower().Trim();
                students.AddRange(
                    _context.Students
                        .AsQueryable()
                        .Include(g => g.Grades)
                        .Include(c => c.Course)
                        .ThenInclude(c => c.Subjects)
                        .Where(x => x.AcademicRecord.ToLower() == academicRecord)
                        .ToList());
            }
            if (!name.IsNullOrEmpty())
            {
                name = name == "null" ? "" : name.ToLower().Trim();
                students.AddRange(
                    _context.Students
                        .AsQueryable()
                        .Include(g => g.Grades)
                        .Include(c => c.Course)
                        .ThenInclude(c => c.Subjects)
                        .Where(x => x.Name.ToLower() == name)
                        .ToList());
            }
            if (courseId > 0)
            {
                students.AddRange(
                    _context.Students
                        .AsQueryable()
                        .Include(g => g.Grades)
                        .Include(c => c.Course)
                        .ThenInclude(c => c.Subjects)
                        .Where(x => x.CourseId == courseId)
                        .ToList());
            }

            if (students.Any() && !status.IsNullOrEmpty())
            {
                status = status == "null" ? "" : status.ToLower();
                students = students.Where(x => x.Status.ToLower().Contains(status)).ToList();
            }

            return students.Distinct().ToList();
        }

        public async Task<bool> Update(Student student)
        {
            BadRequestException.ThrowIfNotEmpty(await VerifyInstanceData(student));

            Student createdStudent = await Find(student.AcademicRecord);

            createdStudent.Name = student.Name;
            createdStudent.Period = student.Period;
            createdStudent.Picture = student.Picture;
            createdStudent.CourseId = student.CourseId;

            _context.Entry(createdStudent).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<string> VerifyInstanceData(Student student)
        {
            string errorMessage = "";
            if (student.AcademicRecord.IsNullOrEmpty())
                errorMessage += "O RA não está preenchido./n";

            if (student.Name.IsNullOrEmpty())
                errorMessage += "O campo de nome deve estar preenchido./n";

            if (student.CourseId <= 0)
                errorMessage += "O ID do curso deve ser maior que zero./n";

            if (student.Period <= 0)
                errorMessage += "O período deve ser maior que zero./n";

            if (!await _context.Courses.AnyAsync(st => st.CourseId == student.CourseId))
                errorMessage += string.Format("Não foi possível encontrar um curso com o ID {0}.", student.CourseId);

            return errorMessage;
        }
    }
}
