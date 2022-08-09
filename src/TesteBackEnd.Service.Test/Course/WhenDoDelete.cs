using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Course
{
    public class WhenDoDelete : CourseServiceTest
    {

        private ICourseService _service;
        private Mock<ICourseService> _serviceMock;
        [Fact(DisplayName = "Is possible run delete method.")]
        public async Task IsPossibleRunDeleteMethod()
        {
            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var resultDelete = await _service.DeleteAsync(CourseId);
            Assert.True(resultDelete);

            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            resultDelete = await _service.DeleteAsync(Guid.NewGuid());
            Assert.False(resultDelete);
        }
    }

}
