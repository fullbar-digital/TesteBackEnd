using App.Domain.Tests.Mocks.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Domain.Tests.Commands
{
    [TestClass]
    public class UpdateStudentrCommandTest
    {
        [TestMethod]
        public void ShouldReturnSuccessWhenSendValidCommand()
        {
            var validCommand = FakeUpdateStudentCommand.validCommand();

            validCommand.Validate();

            Assert.AreEqual(true, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommandName()
        {
            var validCommand = FakeUpdateStudentCommand.invalidCommandName();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommandRegister()
        {
            var validCommand = FakeUpdateStudentCommand.invalidCommandRA();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommandPeriod()
        {
            var validCommand = FakeUpdateStudentCommand.invalidCommandPeriod();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }
        public void ShouldReturnFalseWhenSendInvalidCommandPhoto()
        {
            var validCommand = FakeUpdateStudentCommand.invalidCommandPhoto();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }
    }
}