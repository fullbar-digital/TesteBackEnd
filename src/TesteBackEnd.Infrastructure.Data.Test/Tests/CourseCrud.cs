using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Infrastructure.Data.Context;
using TesteBackEnd.Infrastructure.Data.Repository;

namespace TesteBackEnd.Infrastructure.Data.Test.Tests
{
    public class CourseCrud : DbContextTest, IClassFixture<DbContextTest>
    {
        private ServiceProvider _serviceProvider;

        public CourseCrud(DbContextTest dbContextTest)
        {
            _serviceProvider = dbContextTest.ServiceProvider;
        }

        [Fact(DisplayName = "Course CRUD")]
        [Trait("CRUD", "CourseEntity")]
        public async Task IsPossibleCrudCourse()
        {
            using (var context = _serviceProvider.GetService<TesteBackEndDbContext>())
            {
                CourseRepository _repository = new CourseRepository(context);
                CourseEntity _entity = new CourseEntity
                {
                    Name = "Test Course"
                };
                var course = await _repository.InsertAsync(_entity);
                Assert.NotNull(course);
                Assert.Equal(_entity.Name, course.Name);
                Assert.False(course.Id == Guid.Empty);

                _entity.Name = "New Test Course";
                course = await _repository.UpdateAsync(_entity);
                Assert.NotNull(course);
                Assert.Equal(_entity.Name, course.Name);
                Assert.False(course.Id == Guid.Empty);

                var _exists = await _repository.ExistAsync(_entity.Id);
                Assert.True(_exists);

                course = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(course);

                var courses = await _repository.SelectAsync();
                Assert.NotNull(courses);
            }
        }
    }
}
