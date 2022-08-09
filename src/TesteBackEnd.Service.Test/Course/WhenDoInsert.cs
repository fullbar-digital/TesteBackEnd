using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Course
{
    public class WhenDoInsert : CourseServiceTest
    {
        private ICourseService _service;
        private Mock<ICourseService> _serviceMock;
        [Fact(DisplayName = "Is possible run insert method.")]
        public async Task IsPossibleRunPostMethod()
        {
            _serviceMock = new Mock<ICourseService>();
            _serviceMock.Setup(m => m.InsertAsync(courseDtoCreate)).ReturnsAsync(courseDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(courseDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
        }
    }
}
