using course.manager.webapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Interfaces;
using student.manager.webapi.Models;
using student.manager.webapi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.manager.test
{
    public class TestCourse
    {
        public ICourseService CourseService;
        public ISubjectService SubjectService;
        public DatabaseContext DbContext;
        public static Course _course;
        public List<Subject> _createdSubjects;

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
            MockData();

            CourseService = new CourseService(DbContext,
                                new CourseSubjectService(DbContext,
                                    SubjectService));
        }

        [Test, Order(1)]
        public void Should_Not_Create_Without_Name()
        {
            var course = new Course();

            Assert.ThrowsAsync<BadRequestException>(async () => course = await CourseService.Create(course));
        }

        [Test, Order(2)]
        public void Should_Not_Create_With_ID_Greather_than_Zero()
        {
            var course = new Course { CourseId = 100, Name = "Curso Teste" };
            Assert.ThrowsAsync<BadRequestException>(async () => course = await CourseService.Create(course));
        }

        [Test, Order(3)]
        public void Should_Not_Create_Without_Subjects()
        {
            var course = new Course { Name = "Curso Teste" };
            Assert.ThrowsAsync<BadRequestException>(async () => course = await CourseService.Create(course));
        }

        [Test, Order(4)]
        public void Should_Not_Create_With_Inexistent_Subjects()
        {
            var course = new Course
            {
                Name = "Curso Teste",
                Subjects = new List<Subject>
                {
                    new Subject { SubjectId = 99999 }
                }
            };
            Assert.ThrowsAsync<BadRequestException>(async () => course = await CourseService.Create(course));
        }

        [Test, Order(5)]
        public void Should_Not_Delete_Inexistent()
        {
            bool isSuccess;
            Assert.ThrowsAsync<NotFoundException>(async () => isSuccess = await CourseService.Delete(100));
        }

        [Test, Order(6)]
        public void Should_Throw_Not_Found()
        {
            Course course;
            Assert.ThrowsAsync<NotFoundException>(async () => course = await CourseService.Find(100));
        }

        [Test, Order(7)]
        public void Should_Create()
        {
            _course = CourseService.Create(new Course { Name = "Programação", Subjects = _createdSubjects }).Result;
            Assert.IsNotNull(_course);
            Assert.IsInstanceOf(typeof(Course), _course);
            Assert.IsNotNull(_course.Subjects);
            Assert.IsTrue(_course.Subjects.Count == 3);
        }

        [Test, Order(8)]
        public void Should_Exists()
        {
            _course = CourseService.Find(_course.CourseId).Result.DeepCopy();

            Assert.IsNotNull(_course);
            Assert.IsInstanceOf(typeof(Course), _course);
        }

        [Test, Order(9)]
        public void Should_Update()
        {
            _course.Name = "Programação Linear";
            _course.Subjects = new List<Subject> { _createdSubjects.FirstOrDefault() } ;
            bool isSuccess = CourseService.Update(_course).Result;

            Assert.IsTrue(isSuccess);
        }

        [Test, Order(10)]
        public void Should_Have_Been_Updated()
        {
            _course = CourseService.Find(_course.CourseId).Result;

            Assert.IsTrue(_course.Subjects.Count == 1);
            Assert.IsTrue(_course.Name == "Programação Linear");
        }

        [Test, Order(11)]
        public void Should_Delete_Created()
        {
            bool isSuccess = CourseService.Delete(_course.CourseId).Result;

            Assert.True(isSuccess);

            DeleteCreatedSubjects();
        }

        public void DeleteCreatedSubjects()
        {
            _createdSubjects = DbContext.Subjects.AsQueryable().Where(s => s.Name.Length == 36 /* 36 é o tamanho do GUID criado pelo c# */).ToList();

            if(_createdSubjects.IsNull() || !_createdSubjects.Any()) return;

            foreach (var subject in _createdSubjects)
            {
                DbContext.Subjects.Remove(subject);
            }

            DbContext.SaveChanges();
        }

        public void MockData()
        {
            SubjectService = new SubjectService(DbContext);

            _createdSubjects = SubjectService.CreateMany(new List<Subject>
                                                    {
                                                        new Subject { Name = Guid.NewGuid().ToString(), PassingScore = 3.6 },
                                                        new Subject { Name = Guid.NewGuid().ToString(), PassingScore = 3.6 },
                                                        new Subject { Name = Guid.NewGuid().ToString(), PassingScore = 3.6 },
                                                    }).Result;
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
