using System;
using System.Collections.Generic;
using App.Domain.Commands;
using App.Domain.Models;

namespace App.Domain.Tests.Mocks.Commands
{
    public static class FakeDeleteStudentCommand
    {
        public static DeleteStudentCommand validCommand()
        {
            var id =  Guid.NewGuid();
            return new DeleteStudentCommand(id);
        }

        public static DeleteStudentCommand invalidCommand()
        {
            var id =  Guid.NewGuid();
            return new DeleteStudentCommand();
        }

    }
}