using App.Domain.Repositories;
using App.Domain.Commands;
using App.Domain.Commands.Contracts;
using App.Domain.Handlers.Contracts;
using App.Domain.Models;

namespace App.Domain.Handlers
{
    public class DeleteStudentsHandler : IHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public ICommandResult handle(DeleteStudentCommand command)
        {
            var student = _studentRepository.GetById(command.Id);

           _studentRepository.DeleteStudent(student);

            return new CommandResult("Students deleted with success", true, student);
        }
    }
}