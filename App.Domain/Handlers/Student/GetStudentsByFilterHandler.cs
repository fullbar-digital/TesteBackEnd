using App.Domain.Repositories;
using App.Domain.Commands;
using App.Domain.Commands.Contracts;
using App.Domain.Handlers.Contracts;
using App.Domain.Models;
using System.Collections.Generic;
using App.Domain.Commands.Queries;
using System.Linq;

namespace App.Domain.Handlers
{
    public class GetStudentsByFilterHandler
    {
        private readonly IStudentRepository _studentRepository;
        public GetStudentsByFilterHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public ICommandResult handle(GetStudentsQuery query)
        {

            var students = _studentRepository.GetByFilter(query);

            return new CommandResult("Students finded with success", true, students);
        }
    }
}