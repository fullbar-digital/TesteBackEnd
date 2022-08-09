using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Infrastructure.Data.Context;
using TesteBackEnd.Infrastructure.Data.Repository;

namespace TesteBackEnd.Infrastructure.Data.Test.Tests
{
    public class ScoreCrud : DbContextTest, IClassFixture<DbContextTest>
    {
        private ServiceProvider _serviceProvider;

        public ScoreCrud(DbContextTest dbContextTest)
        {
            _serviceProvider = dbContextTest.ServiceProvider;
        }

        [Fact(DisplayName = "Score CRUD")]
        [Trait("CRUD", "ScoreEntity")]
        public async Task IsPossibleCrudScore()
        {
            using (var context = _serviceProvider.GetService<TesteBackEndDbContext>())
            {
                StudentRepository _studentRepository = new StudentRepository(context);
                CourseRepository _courseRepository = new CourseRepository(context);
                DisciplineRepository _disciplineRepository = new DisciplineRepository(context);
                CourseEntity _course = new CourseEntity
                {
                    Name = "Test Course"
                };
                var course = await _courseRepository.InsertAsync(_course);
                StudentEntity _student = new StudentEntity
                {
                    Name = Faker.Name.FullName(),
                    AcademicRecord = Faker.Identification.UKNationalInsuranceNumber(),
                    CourseId = course.Id,
                    Period = "2022",
                    Photo = "photo.png",
                    Status = Domain.Enums.Status.SCORELESS,
                    CreatedAt = DateTime.Now
                };
                var student = await _studentRepository.InsertAsync(_student);
                ScoreRepository _repository = new ScoreRepository(context);

                DisciplineEntity _discipline = new DisciplineEntity
                {
                    Name = "Test Discipline",
                    CourseId = course.Id,
                    MinimalScore = 7,
                    CreatedAt = DateTime.Now
                };
                var discipline = await _disciplineRepository.InsertAsync(_discipline);

                ScoreEntity _entity = new ScoreEntity
                {
                    Score = Faker.RandomNumber.Next(0, 10),
                    DisciplineId = discipline.Id,
                    StudentId = student.Id,
                    CreatedAt = DateTime.Now
                };

                var score = await _repository.InsertAsync(_entity);
                Assert.NotNull(score);
                Assert.Equal(_entity.Score, score.Score);
                Assert.Equal(_entity.StudentId, score.StudentId);
                Assert.Equal(_entity.DisciplineId, score.DisciplineId);
                Assert.False(score.Id == Guid.Empty);

                _entity.Score = Faker.RandomNumber.Next(0, 10);
                score = await _repository.UpdateAsync(_entity);
                Assert.NotNull(score);
                Assert.Equal(_entity.Score, score.Score);
                Assert.False(score.Id == Guid.Empty);

                var _exists = await _repository.ExistAsync(_entity.Id);
                Assert.True(_exists);

                score = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(course);

                var courses = await _repository.SelectAsync();
                Assert.NotNull(courses);
            }
        }
    }
}
