using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.manager.webapi.Services
{
    public class CourseSubjectService : ICourseSubjectService
    {
        private readonly DatabaseContext _context;
        private readonly ISubjectService _service;

        public CourseSubjectService(DatabaseContext ctx, ISubjectService service)
        {
            _context = ctx;
            _service = service;
        }

        public async Task<bool> Create(long courseId, long subjectId)
        {
            /* Verifica se a materia existe - Caso não exista, uma exception é lançada */
            await _service.Find(subjectId);

            bool alreadyExists = !(await _context.CourseSubjects.FindAsync(courseId, subjectId)).IsNull();
            if (alreadyExists) return true;

            _context.CourseSubjects.Add(new Models.CourseSubject { CourseId = courseId, SubjectId = subjectId });
            int ret = await _context.SaveChangesAsync();

            if (ret == 0) return false;

            return true;
        }

        public async Task<bool> Delete(long courseId, long subjectId)
        {
            var courseSubject = await Find(courseId, subjectId);

            if(courseSubject.IsNull())
                throw new NotFoundException(string.Format("Não foi encontrado um relacionamento entre o Curso {0} e Matéria {1}", courseId, subjectId));
            
            _context.CourseSubjects.Remove(courseSubject);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CourseSubject> Find(long courseId, long subjectId)
        {
            return await _context.CourseSubjects.FindAsync(courseId, subjectId);
        }
    }
}
