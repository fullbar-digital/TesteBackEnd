using App.Domain.Repositories;
using App.Domain.Commands;
using App.Domain.Commands.Contracts;
using App.Domain.Handlers.Contracts;
using App.Domain.Models;
using System.Collections.Generic;

namespace App.Domain.Handlers
{
    public class CreateSubjectHandler : IHandler<CreateSubjectCommand>
    {
        private readonly ISubjectRepository _subjectRepository;

        public CreateSubjectHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public ICommandResult handle(CreateSubjectCommand command)
        {
            //fast fail validations
            command.Validate();

            //validate schema
            if (command.Invalid)
            {
                return new CommandResult("Invalid values request", false, command);
            }

            var subject = new Subject();

            subject.Name = command.Name;
            subject.MinAverageApproval = command.MinAverageApproval;

            _subjectRepository.AddSubject(subject);

            return new CommandResult("Subject created with sucess", true, subject);
        }
    }
}