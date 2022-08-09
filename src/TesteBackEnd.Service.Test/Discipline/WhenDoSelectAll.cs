using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Dtos.Discipline;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Discipline
{
    public class WhenDoSelectAll : DisciplineServiceTest
    {
        private IDisciplineService _service;
        private Mock<IDisciplineService> _serviceMock;
        [Fact(DisplayName = "Is possible run select all method.")]
        public async Task IsPossibleRunGetAllMethod()
        {
            _serviceMock = new Mock<IDisciplineService>();
            _serviceMock.Setup(m => m.SelectAsync()).ReturnsAsync(listDisciplineDto);
            _service = _serviceMock.Object;

            var result = await _service.SelectAsync();

            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<DisciplineDto>();
            _serviceMock = new Mock<IDisciplineService>();
            _serviceMock.Setup(m => m.SelectAsync()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.SelectAsync();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }

}
