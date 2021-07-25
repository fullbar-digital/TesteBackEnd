using course.manager.webapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using student.manager.webapi.Exceptions;
using student.manager.webapi.Infraestructure;
using student.manager.webapi.Models;
using student.manager.webapi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.manager.test
{
    public class TestCourse
    {
        public ICourseService CourseService;
        public DatabaseContext DbContext;
        public static Course _course;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                                        .UseSqlServer("Server=localhost;Database=School_Test;User Id=sa;Password=teste@2021;MultipleActiveResultSets=true")
                                        .Options;

            DbContext = new DatabaseContext(contextOptions);
            DbContext.Database.Migrate();

            CourseService = new CourseService(DbContext, 
                                new CourseSubjectService(DbContext,
                                    new SubjectService(DbContext)));
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
            var course = new Course { CourseId = 100, Name = "Matéria TST" };
            Assert.ThrowsAsync<BadRequestException>(async () => course = await CourseService.Create(course));
        }

        [Test, Order(3)]
        public void Should_Not_Delete_Inexistent()
        {
            bool isSuccess;
            Assert.ThrowsAsync<NotFoundException>(async () => isSuccess = await CourseService.Delete(100));
        }

        [Test, Order(4)]
        public void Should_Throw_Not_Found()
        {
            Course course;
            Assert.ThrowsAsync<NotFoundException>(async () => course = await CourseService.Find(100));            
        }

        [Test, Order(5)]
        public void Should_Create()
        {
            _course = CourseService.Create(new Course { Name = "Matéria TST" }).Result;
            Assert.IsNotNull(_course);
            Assert.IsInstanceOf(typeof(Course), _course);
        }
        
        [Test, Order(6)]
        public void Should_Exists()
        {
            _course = CourseService.Find(_course.CourseId).Result;

            Assert.IsNotNull(_course);
            Assert.IsInstanceOf(typeof(Course), _course);
        }

        [Test, Order(7)]
        public void Should_Update()
        {
            _course.Name = "Matéria Extra Curricular";
            bool isSuccess = CourseService.Update(_course).Result;

            Assert.IsTrue(isSuccess);
        }

        [Test, Order(8)]
        public void Should_Delete_Created()
        {
            bool isSuccess = CourseService.Delete(_course.CourseId).Result;

            Assert.True(isSuccess);
        }
    }
}
