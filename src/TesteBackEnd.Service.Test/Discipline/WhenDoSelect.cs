using Moq;
using TesteBackEnd.Domain.Dtos.Discipline;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Discipline
{
    public class WhenDoGet : DisciplineServiceTest
    {
        private IDisciplineService _service;
        private Mock<IDisciplineService> _serviceMock;

        [Fact(DisplayName = "Is possible run get method.")]
        public async Task IsPossibleRunGetMethod()
        {
            _serviceMock = new Mock<IDisciplineService>();
            _serviceMock.Setup(m => m.SelectAsync(DisciplineId)).ReturnsAsync(disciplineDto);
            _service = _serviceMock.Object;

            var result = await _service.SelectAsync(DisciplineId);
            Assert.NotNull(result);
            Assert.True(result.Id == DisciplineId);
            Assert.Equal(Name, result.Name);
            Assert.Equal(CourseId, result.CourseId);
            Assert.Equal(MinimalScore, result.MinimalScore);

            _serviceMock = new Mock<IDisciplineService>();
            _serviceMock.Setup(m => m.SelectAsync(It.IsAny<Guid>())).Returns(Task.FromResult((DisciplineDto)null));
            _service = _serviceMock.Object;

            var record = await _service.SelectAsync(DisciplineId);
            Assert.Null(record);
        }
    }

}
