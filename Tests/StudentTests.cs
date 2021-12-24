using Domain.Entities;

using Moq;
using FluentAssertions;

using Repositories;

using Xunit;
using AutoMapper;
using Web.Api;
using Web.Api.ViewModels;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class StudentTests
    {
        //ControllerName_MethodName_StateUnderTest_ExpectedBehavior
        [Fact]
        public void StudentController_Add_CourseIdInvalid_MessageforUser()
        {
            //Arrange
            var addStudentExpected = new DefaultApiResult();

            var options = new DbContextOptionsBuilder<EfDbContext>()
            .UseInMemoryDatabase(databaseName: "TesteBackEndInMemoryDatabase")
            .Options;

            var context = new EfDbContext(options);
            var unitOfWork = new UnitOfWork(context);

            var studentAddApiVm = new StudentAddApiVm();
            studentAddApiVm.Name = "Jhonatas Lima";
            studentAddApiVm.Ra = "RA202100001";
            studentAddApiVm.Period = 1;
            studentAddApiVm.CourseId = Guid.NewGuid(); // "Este Id de curso não existe"
            studentAddApiVm.ProfilePicture = "https://dorinapdf.azurewebsites.net/img/1586624207425.jfif";

            var mapper = new Mock<IMapper>();
            mapper.Setup(stp => stp.Map<StudentAddApiVm>(It.IsAny<Student>())).Returns(studentAddApiVm);

            var controller = new StudentController(unitOfWork, mapper.Object);

            //Act
            var studentResult = controller.Add(studentAddApiVm);
            var okResult = studentResult as OkObjectResult;
            DefaultApiResult castedstudentResult = (DefaultApiResult)okResult.Value;

            //Assert
            Assert.NotNull(studentResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.IsType<string>(castedstudentResult.Message);
            Assert.Equal("Este Id de curso não existe", castedstudentResult.Message);

        }
    }
}
