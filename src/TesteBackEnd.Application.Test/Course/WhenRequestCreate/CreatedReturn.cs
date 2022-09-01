using Moq;
using TesteBackEnd.Domain.Interfaces;
using TesteBackEnd.Domain.Dtos.Course;
using TesteBackEnd.Application.Controllers;
using TesteBackEnd.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TesteBackEnd.Application.Test.Course.WhenRequestCreate
{
    public class CreatedReturn
    {
        private ILogger<CoursesController> logger;
        private CoursesController _controller;
        [Fact(DisplayName = "Is possible do Created")]
        public async Task Created()
        {
            var serviceMock = new Mock<ICourseService>();
            var name = "New course";

            serviceMock.Setup(m => m.InsertAsync(It.IsAny<CourseDtoCreate>())).ReturnsAsync(
                new CourseDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = name
                }
            );

            _controller = new CoursesController(serviceMock.Object, new Notifier(), logger);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var courseDtoCreate = new CourseDtoCreate
            {
                Name = name
            };

            var result = await _controller.Post(courseDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CourseDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(courseDtoCreate.Name, resultValue.Name);
        }
    }
}
