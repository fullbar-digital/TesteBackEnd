using App.Domain.Repositories;
using App.Domain.Commands;
using App.Domain.Commands.Contracts;
using App.Domain.Handlers.Contracts;
using App.Domain.Models;
using System.Collections.Generic;

namespace App.Domain.Handlers
{
    public class GetAllStudentsHandler
    {
        private readonly IStudentRepository _studentRepository;
        public GetAllStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public ICommandResult handle()
        {
            var students = _studentRepository.GetAll();

            foreach (var student in students)
            {
                foreach (var subject in student.StudentSubjects)
                {
                    subject.Status = subject.Average > 7 ? "Aprovado" : "Reprovado";
                }
            }

            return new CommandResult("Students finded with success", true, students);
        }
    }
}