using Moq;
using TesteBackEnd.Domain.Dtos.Score;
using TesteBackEnd.Domain.Interfaces;

namespace TesteBackEnd.Service.Test.Score
{
    public class WhenDoGet : ScoreServiceTest
    {
        private IScoreService _service;
        private Mock<IScoreService> _serviceMock;

        [Fact(DisplayName = "Is possible run get method.")]
        public async Task IsPossibleRunGetMethod()
        {
            _serviceMock = new Mock<IScoreService>();
            _serviceMock.Setup(m => m.SelectAsync(ScoreId)).ReturnsAsync(scoreDto);
            _service = _serviceMock.Object;

            var result = await _service.SelectAsync(ScoreId);
            Assert.NotNull(result);
            Assert.Equal(Score, result.Score);

            _serviceMock = new Mock<IScoreService>();
            _serviceMock.Setup(m => m.SelectAsync(It.IsAny<Guid>())).Returns(Task.FromResult((ScoreDto)null));
            _service = _serviceMock.Object;

            var record = await _service.SelectAsync(ScoreId);
            Assert.Null(record);
        }
    }

}
