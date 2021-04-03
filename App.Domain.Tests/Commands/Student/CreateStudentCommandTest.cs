using App.Domain.Tests.Mocks.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Domain.Tests.Commands
{
    [TestClass]
    public class CreateStudentCommandTest
    {
        [TestMethod]
        public void ShouldReturnSuccessWhenSendValidCommand()
        {
            var validCommand = FakeCreateStudentCommand.validCommand();

            validCommand.Validate();

            Assert.AreEqual(true, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommandName()
        {
            var validCommand = FakeCreateStudentCommand.invalidCommandName();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommandRegister()
        {
            var validCommand = FakeCreateStudentCommand.invalidCommandRA();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommandPeriod()
        {
            var validCommand = FakeCreateStudentCommand.invalidCommandPeriod();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommandStatus()
        {
            var validCommand = FakeCreateStudentCommand.invalidCommandStatus();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }

        public void ShouldReturnFalseWhenSendInvalidCommandPhoto()
        {
            var validCommand = FakeCreateStudentCommand.invalidCommandPhoto();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }
 
    }
}