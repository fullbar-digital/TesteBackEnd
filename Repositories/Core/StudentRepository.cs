using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Entities;
using System.Collections.Generic;


namespace Repositories
{
    public class StudentRepository : DefaultRepository<Student>
    {
        public StudentRepository(EfDbContext context) : base(context) { }

        public Dictionary<Student, List<string>> SingleWithCourseAndSchoolReportsWithSubject(Guid id)
        {
            var validations = new List<string>();

            try
            {
                UpdateStatusOfStudent(id);
            }
            catch(Exception ex)
            {
                validations.Add(ex.Message);
            }

            Dictionary<Student, List<string>> model = new Dictionary<Student, List<string>>();

            var student = base._context.Student
                .Include(i => i.Course)
                .Include(i => i.SchoolReports)
                .ThenInclude(ti => ti.Subject)
                .AsSplitQuery()
                .Single(sg => sg.Id.Equals(id));

            model.Add(student, validations);
            return model;

        }

        private void UpdateStatusOfStudent(Guid studentId)
        {
            //O Aluno precisa ter notas em cada diciplina que o curso contempla
            //O status do Aluno deverá ser aprovado ou reprovado na diciplina X (nota sendo maior que 7.0.)

            var student = _context.Student.Include(i => i.SchoolReports).Single(s => s.Id.Equals(studentId));
            var courseOfStudent = _context.Course.Include(i => i.Subjects).Single(s => s.Id.Equals(student.CourseId));

            student.Status = "Aprovado";
            foreach (var subject in courseOfStudent.Subjects)
            {
                var schoolReportsOfsubject = student.SchoolReports.FirstOrDefault(f => f.SubjectId.Equals(subject.Id));
                if (schoolReportsOfsubject == null)
                {
                    student.Status = ($"Aluno {student.Name} sem nota na disciplina {subject.Name}");
                }
                else if (schoolReportsOfsubject.Grade < 7.0m)
                {
                    student.Status = $"Aluno reprovado na disciplina {subject.Name}";
                    break;
                }
            }
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
