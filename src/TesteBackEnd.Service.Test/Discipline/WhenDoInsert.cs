using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Discipline
{
    public class WhenDoInsert : DisciplineServiceTest
    {
        private IDisciplineService _service;
        private Mock<IDisciplineService> _serviceMock;
        [Fact(DisplayName = "Is possible run insert method.")]
        public async Task IsPossibleRunPostMethod()
        {
            _serviceMock = new Mock<IDisciplineService>();
            _serviceMock.Setup(m => m.InsertAsync(disciplineDtoCreate)).ReturnsAsync(disciplineDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(disciplineDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
        }
    }
}
