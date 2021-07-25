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
                throw new BadRequestException("Um novo registro não pode conter um ID diferente de zero!");
            if (subject.Name.IsNullOrEmpty())
                throw new BadRequestException("O nome da matéria não pode estar em branco!");
            if (subject.PassingScore < 0)
                throw new BadRequestException("A nota mínima de aprovação deve ser maior ou igual a zero!");

            bool subjectExists =
                await _context.Subjects.AsQueryable().AnyAsync(c => c.Name.ToLower() == subject.Name.ToLower());

            if (subjectExists)
                throw new BadRequestException("Uma matéria com este nome já existe!");


            await _context.Subjects.AddAsync(subject);
            _context.SaveChanges();

            return await _context.Subjects.AsQueryable().FirstAsync(c => c.Name.ToLower() == subject.Name.ToLower());
        }

        public async Task<List<Subject>> CreateMany(List<Subject> subjects)
        {
            var createdSubjects = new List<Subject>();

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                foreach (Subject subject in subjects)
                {
                    createdSubjects.Add(await Create(subject));
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message ?? e.Message);
                transaction.Rollback();
                throw e;
            }

            return createdSubjects;
        }

        public async Task<bool> Delete(long subjectId)
        {
            Subject subject = await Find(subjectId);

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Subject> Find(long subjectId)
        {
            if (subjectId <= 0)
                throw new BadRequestException("Informe um número maior que zero!");

            Subject subject =
                await _context.Subjects.FindAsync(subjectId);

            if (subject.IsNull())
                throw new NotFoundException("Matéria não encontrada!");

            return subject;
        }

        public async Task<bool> Update(Subject subject)
        {
            if (subject.PassingScore < 0)
                throw new BadRequestException("A nota mínima de aprovação deve ser maior ou igual a zero!");

            Subject createdSubject = await Find(subject.SubjectId);

            if (!subject.Name.IsNullOrEmpty())
                createdSubject.Name = subject.Name;

            if (subject.PassingScore != 0)
                createdSubject.PassingScore = subject.PassingScore;

            _context.Entry(createdSubject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
