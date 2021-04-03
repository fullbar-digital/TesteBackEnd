using System;
using System.Collections.Generic;
using App.Domain.Commands;
using App.Domain.Models;

namespace App.Domain.Tests.Mocks.Commands
{
    public static class FakeUpdateStudentCommand
    {   
        public static Guid Id  = Guid.NewGuid();
        public static Guid Courseid  = Guid.NewGuid();

        public static UpdateStudentrCommand validCommand()
        {

            return new UpdateStudentrCommand(Id, "New name", "new Register", "New period", "New Photo", Courseid);
        }

        public static UpdateStudentrCommand invalidCommandRA()
        {
            return new UpdateStudentrCommand(Id, "New name", "", "New period", "New Photo", Courseid);

        }
        public static UpdateStudentrCommand invalidCommandName()
        {

            return new UpdateStudentrCommand(Id, "", "new Register", "New period", "New Photo", Courseid);
        }

        public static UpdateStudentrCommand invalidCommandPeriod()
        {
            return new UpdateStudentrCommand(Id, "New name", "new Register", "", "New Photo", Courseid);
        }

        public static UpdateStudentrCommand invalidCommandPhoto()
        {

            return new UpdateStudentrCommand(Id, "New name", "new Register", "New period", "" , Courseid);

        }

    }
}