using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Score
{
    public class WhenDoUpdate : ScoreServiceTest
    {
        private IScoreService _service;
        private Mock<IScoreService> _serviceMock;
        [Fact(DisplayName = "Is possible run update method.")]
        public async Task IsPossibleRunPutMethod()
        {
            _serviceMock = new Mock<IScoreService>();
            _serviceMock.Setup(m => m.InsertAsync(scoreDtoCreate)).ReturnsAsync(scoreDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(scoreDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Score, result.Score);
            Assert.Equal(StudentId, result.StudentId);
            Assert.Equal(DisciplineId, result.DisciplineId);

            _serviceMock = new Mock<IScoreService>();
            _serviceMock.Setup(m => m.UpdateAsync(scoreDtoUpdate)).ReturnsAsync(scoreDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.UpdateAsync(scoreDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(AlteredScore, resultUpdate.Score);
            Assert.Equal(AlteredStudentId, resultUpdate.StudentId);
            Assert.Equal(AlteredDisciplineId, resultUpdate.DisciplineId);
        }
    }
}
