using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Student
{
    public class WhenDoInsert : StudentServiceTest
    {
        private IStudentService _service;
        private Mock<IStudentService> _serviceMock;
        [Fact(DisplayName = "Is possible run insert method.")]
        public async Task IsPossibleRunPostMethod()
        {
            _serviceMock = new Mock<IStudentService>();
            _serviceMock.Setup(m => m.InsertAsync(studentDtoCreate)).ReturnsAsync(studentDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(studentDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
            Assert.Equal(AcademicRecord, result.AcademicRecord);
            Assert.Equal(Photo, result.Photo);
            Assert.Equal(Period, result.Period);
        }
    }
}
