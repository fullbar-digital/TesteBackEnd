using System.Collections.Generic;
using App.Domain.Commands;
using App.Domain.Models;

namespace App.Domain.Tests.Mocks.Commands
{
    public static class FakeCreateSubjectCommand
    {
        public static CreateSubjectCommand validCommand()
        {
            var subjects =  new List<Subject>();
            return new CreateSubjectCommand("Matheus Angelo", 0);
        }

        public static CreateSubjectCommand invalidCommand()
        {
            var subjects =  new List<Subject>();

            return new CreateSubjectCommand("", 0);
        }

    }
}