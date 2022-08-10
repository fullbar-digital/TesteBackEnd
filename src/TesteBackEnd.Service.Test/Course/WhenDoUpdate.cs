using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Course
{
    public class WhenDoUpdate : CourseServiceTest
    {
        private ICourseService _service;
        private Mock<ICourseService> _serviceMock;
        [Fact(DisplayName = "Is possible run update method.")]
        public async Task IsPossibleRunPutMethod()
        {
            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.InsertAsync(courseDtoCreate)).ReturnsAsync(courseDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(courseDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);

            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.UpdateAsync(CourseId, courseDtoUpdate)).ReturnsAsync(courseDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.UpdateAsync(CourseId, courseDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(AlteredName, resultUpdate.Name);
        }
    }

}
