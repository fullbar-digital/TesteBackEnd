using App.Domain.Tests.Mocks.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Domain.Tests.Commands
{
    [TestClass]
    public class DeleteStudentCommandTest
    {
        [TestMethod]
        public void ShouldReturnSuccessWhenSendValidCommand()
        {
            var validCommand = FakeDeleteStudentCommand.validCommand();

            validCommand.Validate();

            Assert.AreEqual(true, validCommand.Valid);
        }
        public void ShouldReturnSuccessWhenSendInvalidCommand()
        {
            var validCommand = FakeDeleteStudentCommand.invalidCommand();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);
        }
    }
}