using Moq;
using TesteBackEnd.Domain.Dtos.Course;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Course
{
    public class WhenDoGet : CourseServiceTest
    {
        private ICourseService _service;
        private Mock<ICourseService> _serviceMock;

        [Fact(DisplayName = "Is possible run get method.")]
        public async Task IsPossibleRunGetMethod()
        {
            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.SelectAsync(CourseId)).ReturnsAsync(courseDto);
            _service = _serviceMock.Object;

            var result = await _service.SelectAsync(CourseId);
            Assert.NotNull(result);
            Assert.True(result.Id == CourseId);
            Assert.Equal(Name, result.Name);

            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.SelectAsync(It.IsAny<Guid>())).Returns(Task.FromResult((CourseDto)null));
            _service = _serviceMock.Object;

            var record = await _service.SelectAsync(CourseId);
            Assert.Null(record);
        }
    }

}
