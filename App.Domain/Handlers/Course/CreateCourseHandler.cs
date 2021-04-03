using App.Domain.Repositories;
using App.Domain.Commands;
using App.Domain.Commands.Contracts;
using App.Domain.Handlers.Contracts;
using App.Domain.Models;
using System.Collections.Generic;

namespace App.Domain.Handlers
{
    public class CreateCourseHandler : IHandler<CreateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public ICommandResult handle(CreateCourseCommand command)
        {
            //fast fail validations
            command.Validate();

            //validate schema
            if (command.Invalid)
            {
                return new CommandResult("Invalid values request", false, command);
            }

            var course = new Course();

            course.Name = command.Name;
            course.Subjects = command.Subjects;

            _courseRepository.AddCourse(course);

            return new CommandResult("Course created with sucess", true, course);
        }
    }
}