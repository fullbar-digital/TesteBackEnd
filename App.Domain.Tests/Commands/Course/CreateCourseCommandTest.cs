using App.Domain.Tests.Mocks.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Domain.Tests.Commands
{
    [TestClass]
    public class CommandCreateCourseTests
    {
       [TestMethod]
        public void ShouldReturnSuccessWhenSendValidCommand()
        {
            var validCommand = FakeCommandCreateCourse.validCommand();

            validCommand.Validate();

            Assert.AreEqual(true, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommand()
        {
            var validCommand = FakeCommandCreateCourse.invalidCommand();

            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }
    }
}