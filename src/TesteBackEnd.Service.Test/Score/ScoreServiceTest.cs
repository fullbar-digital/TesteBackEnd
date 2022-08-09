using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackEnd.Domain.Dtos.Score;

namespace TesteBackEnd.Service.Test.Score
{
    public class ScoreServiceTest
    {
        public static Guid ScoreId { get; set; }
        public static Guid StudentId { get; set; }
        public static Guid DisciplineId { get; set; }
        public static decimal Score { get; set; }
        public static Guid AlteredStudentId { get; set; }
        public static Guid AlteredDisciplineId { get; set; }
        public static decimal AlteredScore { get; set; }
        public List<ScoreDto> listScoreDto = new List<ScoreDto>();
        public ScoreDto scoreDto;
        public ScoreDtoCreate scoreDtoCreate;
        public ScoreDtoCreateResult scoreDtoCreateResult;
        public ScoreDtoUpdate scoreDtoUpdate;
        public ScoreDtoUpdateResult scoreDtoUpdateResult;

        public ScoreServiceTest()
        {
            ScoreId = Guid.NewGuid();
            StudentId = Guid.NewGuid();
            DisciplineId = Guid.NewGuid();
            Score = Faker.RandomNumber.Next(0, 10);
            AlteredStudentId = Guid.NewGuid();
            AlteredDisciplineId = Guid.NewGuid();
            AlteredScore = Faker.RandomNumber.Next(0, 10);


            for (int i = 0; i < 10; i++)
            {
                var dto = new ScoreDto
                {

                    Score = Faker.RandomNumber.Next(0, 10),

                };
                listScoreDto.Add(dto);
            }

            scoreDto = new ScoreDto
            {

                Score = Score
            };

            scoreDtoCreate = new ScoreDtoCreate
            {
                StudentId = StudentId,
                DisciplineId = DisciplineId,
                Score = Score
            };

            scoreDtoCreateResult = new ScoreDtoCreateResult
            {
                Id = ScoreId,
                StudentId = StudentId,
                DisciplineId = DisciplineId,
                Score = Score
            };

            scoreDtoUpdate = new ScoreDtoUpdate
            {
                Id = ScoreId,
                StudentId = AlteredStudentId,
                DisciplineId = AlteredDisciplineId,
                Score = AlteredScore
            };

            scoreDtoUpdateResult = new ScoreDtoUpdateResult
            {
                Id = ScoreId,
                StudentId = AlteredStudentId,
                DisciplineId = AlteredDisciplineId,
                Score = AlteredScore
            };
        }
    }
}
