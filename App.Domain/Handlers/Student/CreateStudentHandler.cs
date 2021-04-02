using App.Domain.Repositories;
using App.Domain.Commands;
using App.Domain.Commands.Contracts;
using App.Domain.Handlers.Contracts;
using App.Domain.Models;
using System.Collections.Generic;

namespace App.Domain.Handlers
{
    public class CreateStudentHandler : IHandler<CreateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public ICommandResult handle(CreateStudentCommand command)
        {
            //fast fail validations
            command.Validate();

            //validate schema
            if (command.Invalid)
            {
                return new CommandResult("Invalid values request", false, command);
            }

            var student = new Student();
            var subjects = new List<StudentSubject>();
            var course = new Course();

            student.Name = command.Name;
            student.Register = command.Register;
            student.Period = command.Period;
            student.Photo = command.Photo;
            student.Status = command.Status;
            student.StudentSubjects = subjects;
            student.Course = course;

            _studentRepository.AddStudent(student);

            return new CommandResult("Student created with sucess", true, student);
        }
    }
}