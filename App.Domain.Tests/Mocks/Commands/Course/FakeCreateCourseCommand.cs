using System.Collections.Generic;
using App.Domain.Commands;
using App.Domain.Models;

namespace App.Domain.Tests.Mocks.Commands
{
    public static class FakeCommandCreateCourse
    {
        public static CreateCourseCommand validCommand()
        {
            var subjects =  new List<Subject>();
            return new CreateCourseCommand("Matheus Angelo", subjects);
        }

        public static CreateCourseCommand invalidCommand()
        {
            var subjects =  new List<Subject>();

            return new CreateCourseCommand("", subjects);
        }

    }
}