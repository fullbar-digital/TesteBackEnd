using System.Collections.Generic;
using App.Domain.Commands;
using App.Domain.Models;

namespace App.Domain.Tests.Mocks.Commands
{
    public static class FakeCreateStudentCommand
    {
        public static CreateStudentCommand validCommand()
        {
            return new CreateStudentCommand("Matheus Angelo", "D06JGF3", "Period", "Status", "www.google.com");
        }


        public static CreateStudentCommand invalidCommandRA()
        {

            return new CreateStudentCommand("Matheus Angelo", "", "Period", "Status", "www.google.com");

        }

        public static CreateStudentCommand invalidCommandName()
        {

            return new CreateStudentCommand("", "D06JGF3", "Period", "Status", "www.google.com");

        }

        public static CreateStudentCommand invalidCommandPeriod()
        {

            return new CreateStudentCommand("Matheus Angelo", "D06JGF3", "", "Status", "www.google.com");

        }

                public static CreateStudentCommand invalidCommandStatus()
        {

            return new CreateStudentCommand("Matheus Angelo", "D06JGF3", "Period", "", "www.google.com");

        }

                public static CreateStudentCommand invalidCommandPhoto()
        {

            return new CreateStudentCommand("Matheus Angelo", "D06JGF3", "Period", "Status", "");

        }

    }
}