using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Infrastructure.Data.Context;
using TesteBackEnd.Infrastructure.Data.Repository;

namespace TesteBackEnd.Infrastructure.Data.Test.Tests
{
    public class DisciplineCrud : DbContextTest, IClassFixture<DbContextTest>
    {
        private ServiceProvider _serviceProvider;

        public DisciplineCrud(DbContextTest dbContextTest)
        {
            _serviceProvider = dbContextTest.ServiceProvider;
        }

        [Fact(DisplayName = "Discipline CRUD")]
        [Trait("CRUD", "DisciplineEntity")]
        public async Task IsPossibleCrudDiscipline()
        {
            using (var context = _serviceProvider.GetService<TesteBackEndDbContext>())
            {

                DisciplineRepository _repository = new DisciplineRepository(context);
                CourseRepository _courseRepository = new CourseRepository(context);
                CourseEntity _course = new CourseEntity
                {
                    Name = "Test Course"
                };
                var course = await _courseRepository.InsertAsync(_course);

                DisciplineEntity _entity = new DisciplineEntity
                {
                    Name = "Test Discipline",
                    CourseId = course.Id,
                    MinimalScore = 7,
                    CreatedAt = DateTime.Now
                };
                var discipline = await _repository.InsertAsync(_entity);
                Assert.NotNull(discipline);
                Assert.Equal(_entity.Name, discipline.Name);
                Assert.False(discipline.Id == Guid.Empty);

                _entity.Name = "New Test Discipline";
                discipline = await _repository.UpdateAsync(_entity);
                Assert.NotNull(discipline);
                Assert.Equal(_entity.Name, discipline.Name);
                Assert.Equal(_entity.CourseId, discipline.CourseId);
                Assert.Equal(_entity.MinimalScore, discipline.MinimalScore);
                Assert.Equal(_entity.CreatedAt, discipline.CreatedAt);
                Assert.False(discipline.Id == Guid.Empty);

                var _exists = await _repository.ExistAsync(_entity.Id);
                Assert.True(_exists);

                discipline = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(discipline);

                var disciplines = await _repository.SelectAsync();
                Assert.NotNull(disciplines);
            }
        }
    }
}
