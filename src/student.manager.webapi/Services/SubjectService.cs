using Microsoft.AspNetCore.Http;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using student.manager.webapi.Exceptions;

namespace student.manager.webapi.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly DatabaseContext _context;

        public SubjectService(DatabaseContext ctx)
        {
            _context = ctx;
        }
        
        public async Task<Subject> Create(Subject subject)
        {
            if (subject.SubjectId != 0)
                throw new BadHttpRequestException("Um novo registro não pode conter um ID diferente de zero!");
            
            bool subjectExists =
                await _context.Subjects.AsQueryable().AnyAsync(c => c.Name.ToLower() == subject.Name.ToLower());
            
            if (subjectExists)
                throw new BadHttpRequestException("Uma matéria com este nome já existe!");


            await _context.Subjects.AddAsync(subject);
            _context.SaveChanges();

            return await _context.Subjects.AsQueryable().FirstAsync(c => c.Name.ToLower() == subject.Name.ToLower());
        }

        public async Task<bool> Delete(long subjectId)
        {
            if(subjectId <= 0)
                throw new BadHttpRequestException("Informe um número maior que zero!");

            Subject subject =
                await _context.Subjects.FindAsync(subjectId);

            if (subject.IsNull())
                throw new NotFoundException("Matéria não encontrada!");

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Subject> Find(long subjectId)
        {
            if(subjectId <= 0)
                throw new BadHttpRequestException("Informe um número maior que zero!");

            Subject subject =
                await _context.Subjects.FindAsync(subjectId);

            if (subject.IsNull())
                throw new NotFoundException("Matéria não encontrada!");

            return subject;
        }

        public async Task<bool> Update(Subject subject)
        {
            if(subject.SubjectId <= 0)
                throw new BadHttpRequestException("Informe um número maior que zero!");

            Subject createdSubject =
                await _context.Subjects.FindAsync(subject.SubjectId);

            if (createdSubject.IsNull())
                throw new NotFoundException("Matéria não encontrada, portanto não pode ser atualizada!");
            
            _context.Entry(subject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
