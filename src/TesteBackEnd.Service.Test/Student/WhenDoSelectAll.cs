using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Dtos.Student;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Student
{
    public class WhenDoSelectAll : StudentServiceTest
    {
        private IStudentService _service;
        private Mock<IStudentService> _serviceMock;
        [Fact(DisplayName = "Is possible run select all method.")]
        public async Task IsPossibleRunGetAllMethod()
        {
            _serviceMock = new Mock<IStudentService>();
            _serviceMock.Setup(m => m.SelectAsync()).ReturnsAsync(listStudentDto);
            _service = _serviceMock.Object;

            var result = await _service.SelectAsync();

            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<StudentDto>();
            _serviceMock = new Mock<IStudentService>();
            _serviceMock.Setup(m => m.SelectAsync()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.SelectAsync();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }

}
