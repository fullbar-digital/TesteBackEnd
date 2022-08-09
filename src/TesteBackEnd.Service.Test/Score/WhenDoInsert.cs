using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Score
{
    public class WhenDoInsert : ScoreServiceTest
    {
        private IScoreService _service;
        private Mock<IScoreService> _serviceMock;
        [Fact(DisplayName = "Is possible run insert method.")]
        public async Task IsPossibleRunPostMethod()
        {
            _serviceMock = new Mock<IScoreService>();
            _serviceMock.Setup(m => m.InsertAsync(scoreDtoCreate)).ReturnsAsync(scoreDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(scoreDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Score, result.Score);
            Assert.Equal(StudentId, result.StudentId);
            Assert.Equal(DisciplineId, result.DisciplineId);
        }
    }
}
