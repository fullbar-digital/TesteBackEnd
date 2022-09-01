using Moq;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Student
{
    public class WhenDoGet : StudentServiceTest
    {
        private IStudentService _service;
        private Mock<IStudentService> _serviceMock;

        [Fact(DisplayName = "Is possible run get method.")]
        public async Task IsPossibleRunGetMethod()
        {
            _serviceMock = new Mock<IStudentService>();
            _serviceMock.Setup(m => m.SelectAsync(StudentId)).ReturnsAsync(studentDto);
            _service = _serviceMock.Object;

            var result = await _service.SelectAsync(StudentId);
            Assert.NotNull(result);
            Assert.True(result.Id == StudentId);
            Assert.Equal(Name, result.Name);
            Assert.Equal(AcademicRecord, result.AcademicRecord);
            Assert.Equal(Photo, result.Photo);
            Assert.Equal(Period, result.Period);

            _serviceMock = new Mock<IStudentService>();
            _serviceMock.Setup(m => m.SelectAsync(It.IsAny<Guid>())).Returns(Task.FromResult((StudentDto)null));
            _service = _serviceMock.Object;

            var record = await _service.SelectAsync(StudentId);
            Assert.Null(record);
        }
    }

}
