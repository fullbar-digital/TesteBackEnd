using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Discipline
{
    public class WhenDoUpdate : DisciplineServiceTest
    {
        private IDisciplineService _service;
        private Mock<IDisciplineService> _serviceMock;
        [Fact(DisplayName = "Is possible run update method.")]
        public async Task IsPossibleRunPutMethod()
        {
            _serviceMock = new Mock<IDisciplineService>();
            _serviceMock.Setup(m => m.InsertAsync(disciplineDtoCreate)).ReturnsAsync(disciplineDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(disciplineDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
            Assert.Equal(CourseId, result.CourseId);
            Assert.Equal(MinimalScore, result.MinimalScore);

            _serviceMock = new Mock<IDisciplineService>();
            _serviceMock.Setup(m => m.UpdateAsync(disciplineDtoUpdate)).ReturnsAsync(disciplineDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.UpdateAsync(disciplineDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(AlteredName, resultUpdate.Name);
            Assert.Equal(AlteredCourseId, resultUpdate.CourseId);
            Assert.Equal(AlteredMinimalScore, resultUpdate.MinimalScore);
        }
    }

}
