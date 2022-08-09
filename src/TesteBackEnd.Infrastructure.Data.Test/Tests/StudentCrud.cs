using Microsoft.Extensions.DependencyInjection;
using TesteBackEnd.Domain.Entities;
using TesteBackEnd.Infrastructure.Data.Context;
using TesteBackEnd.Infrastructure.Data.Repository;

namespace TesteBackEnd.Infrastructure.Data.Test.Tests
{
    public class StudentCrud : DbContextTest, IClassFixture<DbContextTest>
    {
        private ServiceProvider _serviceProvider;

        public StudentCrud(DbContextTest dbContextTest)
        {
            _serviceProvider = dbContextTest.ServiceProvider;
        }

        [Fact(DisplayName = "Student CRUD")]
        [Trait("CRUD", "StudentEntity")]
        public async Task IsPossibleCrudStudent()
        {
            using (var context = _serviceProvider.GetService<TesteBackEndDbContext>())
            {
                StudentRepository _repository = new StudentRepository(context);
                CourseRepository _courseRepository = new CourseRepository(context);
                CourseEntity _course = new CourseEntity
                {
                    Name = "Test Course"
                };
                var course = await _courseRepository.InsertAsync(_course);
                StudentEntity _entity = new StudentEntity
                {
                    Name = Faker.Name.FullName(),
                    AcademicRecord = Faker.Identification.UKNationalInsuranceNumber(),
                    CourseId = course.Id,
                    Period = "2022",
                    Photo = "photo.png",
                    Status = Domain.Enums.Status.SCORELESS,
                    CreatedAt = DateTime.Now

                };
                var student = await _repository.InsertAsync(_entity);
                Assert.NotNull(student);
                Assert.Equal(_entity.Name, student.Name);
                Assert.Equal(_entity.AcademicRecord, student.AcademicRecord);
                Assert.Equal(_entity.CourseId, student.CourseId);
                Assert.Equal(_entity.Period, student.Period);
                Assert.Equal(_entity.Photo, student.Photo);
                Assert.Equal(_entity.Status, student.Status);
                Assert.False(student.Id == Guid.Empty);

                _entity.Name = Faker.Name.FullName();
                student = await _repository.UpdateAsync(_entity);
                Assert.NotNull(student);
                Assert.Equal(_entity.Name, student.Name);
                Assert.Equal(_entity.AcademicRecord, student.AcademicRecord);
                Assert.Equal(_entity.CourseId, student.CourseId);
                Assert.Equal(_entity.Period, student.Period);
                Assert.Equal(_entity.Photo, student.Photo);
                Assert.False(student.Id == Guid.Empty);

                var _exists = await _repository.ExistAsync(_entity.Id);
                Assert.True(_exists);


                student = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(student);
                Assert.Equal(_entity.Id, student.Id);

                var students = await _repository.SelectAsync();
                Assert.NotNull(students);

                students = await _repository.FilterAsync(r =>
                    (string.IsNullOrEmpty(student.Name) ||
                    (!string.IsNullOrEmpty(student.Name) && r.Name.ToLower().Contains(student.Name.ToLower()))) &&
                    (string.IsNullOrEmpty(course.Name) ||
                    (!string.IsNullOrEmpty(course.Name) && r.Course.Name.ToLower().Contains(course.Name.ToLower()))) &&
                    (string.IsNullOrEmpty(student.AcademicRecord) ||
                    (!string.IsNullOrEmpty(student.AcademicRecord) && r.AcademicRecord.ToLower().Contains(student.AcademicRecord.ToLower())))
                    && (r.Status == student.Status));

                Assert.NotNull(students);
            }
        }
    }
}
