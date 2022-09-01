using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Student
{
    public class WhenDoUpdate : StudentServiceTest
    {
        private IStudentService _service;
        private Mock<IStudentService> _serviceMock;
        [Fact(DisplayName = "Is possible run update method.")]
        public async Task IsPossibleRunPutMethod()
        {
            _serviceMock = new Mock<IStudentService>();
            _serviceMock.Setup(m => m.InsertAsync(studentDtoCreate)).ReturnsAsync(studentDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(studentDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);

            _serviceMock = new Mock<IStudentService>();
            _serviceMock.Setup(m => m.UpdateAsync(StudentId, studentDtoUpdate)).ReturnsAsync(studentDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.UpdateAsync(StudentId, studentDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(AlteredName, resultUpdate.Name);
        }
    }

}
