using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;
using student.manager.webapi.Services;
using System;
using System.IO;

namespace student.manager.test
{
    public class TestSubject
    {
        public ISubjectService SubjectService;
        public DatabaseContext DbContext;
        public static Subject _subject;

        [OneTimeSetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            var contextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                                        .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                                        .Options;

            DbContext = new DatabaseContext(contextOptions);
            DbContext.Database.Migrate();
            DeleteMockedData();
            SubjectService = new SubjectService(DbContext);
        }

        [Test, Order(1)]
        public void Should_Not_Create_Without_Name()
        {
            var subject = new Subject();

            Assert.ThrowsAsync<BadRequestException>(async () => subject = await SubjectService.Create(subject));
        }

        [Test, Order(2)]
        public void Should_Not_Create_With_ID_Greather_than_Zero()
        {
            var subject = new Subject { SubjectId = 100, Name = "Matéria TST" };
            Assert.ThrowsAsync<BadRequestException>(async () => subject = await SubjectService.Create(subject));
        }

        [Test, Order(3)]
        public void Passing_Score_Should_Be_Greater_Than_Zero()
        {
            var subject = new Subject { Name = "Matéria TST" };
            Assert.ThrowsAsync<BadRequestException>(async () => subject = await SubjectService.Create(subject));
        }

        [Test, Order(4)]
        public void Should_Not_Delete_Inexistent()
        {
            bool isSuccess;
            Assert.ThrowsAsync<NotFoundException>(async () => isSuccess = await SubjectService.Delete(100));
        }

        [Test, Order(5)]
        public void Should_Throw_Not_Found()
        {
            Subject subject;
            Assert.ThrowsAsync<NotFoundException>(async () => subject = await SubjectService.Find(100));            
        }

        [Test, Order(6)]
        public void Should_Create()
        {
            _subject = SubjectService.Create(new Subject { Name = "Matéria TST", PassingScore = 7 }).Result;
            Assert.IsNotNull(_subject);
            Assert.IsInstanceOf(typeof(Subject), _subject);
        }
        
        [Test, Order(7)]
        public void Should_Exists()
        {
            _subject = SubjectService.Find(_subject.SubjectId).Result;

            Assert.IsNotNull(_subject);
            Assert.IsInstanceOf(typeof(Subject), _subject);
        }

        [Test, Order(8)]
        public void Should_Update()
        {
            _subject.Name = "Matéria Extra Curricular";
            bool isSuccess = SubjectService.Update(_subject).Result;

            Assert.IsTrue(isSuccess);
        }

        [Test, Order(9)]
        public void Should_Delete_Created()
        {
            bool isSuccess = SubjectService.Delete(_subject.SubjectId).Result;

            Assert.True(isSuccess);
        }

        public void DeleteMockedData()
        {
            DbContext.CourseSubjects.RemoveRange(DbContext.CourseSubjects);
            DbContext.Courses.RemoveRange(DbContext.Courses);
            DbContext.Subjects.RemoveRange(DbContext.Subjects);
            DbContext.Students.RemoveRange(DbContext.Students);
            DbContext.Grades.RemoveRange(DbContext.Grades);

            DbContext.SaveChanges();
        }
    }
}