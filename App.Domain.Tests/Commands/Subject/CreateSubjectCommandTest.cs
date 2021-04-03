using App.Domain.Tests.Mocks.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Domain.Tests.Commands
{
    [TestClass]
    public class CreateSubjectCommandTests
    {
        [TestMethod]
        public void ShouldReturnSuccessWhenSendValidCommand()
        {
            var validCommand = FakeCreateSubjectCommand.validCommand();
            
            validCommand.Validate();

            Assert.AreEqual(true, validCommand.Valid);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenSendInvalidCommand()
        {
            var validCommand = FakeCreateSubjectCommand.invalidCommand();
            
            validCommand.Validate();

            Assert.AreEqual(false, validCommand.Valid);

        }
    }
}