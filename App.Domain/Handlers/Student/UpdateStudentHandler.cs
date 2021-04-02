using App.Domain.Repositories;
using App.Domain.Commands;
using App.Domain.Commands.Contracts;
using App.Domain.Handlers.Contracts;
using App.Domain.Models;

namespace App.Domain.Handlers
{
    public class UpdateStudentHandler : IHandler<UpdateStudentrCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public ICommandResult handle(UpdateStudentrCommand command)
        {
            //fast fail validations
            command.Validate();

            //validate schema
            if (command.Invalid)
            {
                return new CommandResult("Invalid values request", false, command);
            }

            var student = _studentRepository.GetById(command.Id);

            student.Name = command.Name;
            student.Register = command.Register;
            student.Period = command.Period;
            student.Photo = command.Photo;

            _studentRepository.UpdateStudent(student);

            return new CommandResult("Student updated with sucess", true, student);
        }
    }
}