using student.manager.webapi.Interfaces;
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
using course.manager.webapi.Interfaces;

namespace student.manager.test
{
    public class TestStudent
    {
        public DatabaseContext DbContext;
        public static string _academicRecord;
        public IStudentService StudentService;
        public List<Course> MockedCourses;

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

            StudentService = new StudentService(DbContext);

            _academicRecord = Guid.NewGuid().ToString();
            DeleteMockedData();
            MockData();
        }

        [Test, Order(1)]
        public void Should_Not_Create_Without_AcademicRecord()
        {
            Student student = new Student 
            {
                Name = "Jonathan Silva",
                CourseId = MockedCourses.FirstOrDefault().CourseId,
                Period = 5,
                Picture = @"\\vmtst\img.png"
            };

            Assert.ThrowsAsync<BadRequestException>(async () => student = await StudentService.Create(student));
        }

        [Test, Order(2)]
        public void Should_Not_Create_Without_Name()
        {
            Student student = new Student 
            {
                AcademicRecord = _academicRecord,
                CourseId = MockedCourses.FirstOrDefault().CourseId,
                Period = 5,
                Picture = @"\\vmtst\img.png"
            };

            Assert.ThrowsAsync<BadRequestException>(async () => student = await StudentService.Create(student));
        }
        
        [Test, Order(3)]
        public void Should_Not_Create_Without_Course()
        {
            Student student = new Student 
            {
                AcademicRecord = _academicRecord,
                Name = "Jonathan Silva",
                Period = 5,
                Picture = @"\\vmtst\img.png"
            };

            Assert.ThrowsAsync<BadRequestException>(async () => student = await StudentService.Create(student));
        }

        [Test, Order(4)]
        public void Period_Should_be_greater_than_zero()
        {
            Student student = new Student 
            {
                AcademicRecord = _academicRecord,
                Name = "Jonathan Silva",
                CourseId = MockedCourses.FirstOrDefault().CourseId,
                Period = 0,
                Picture = @"\\vmtst\img.png"
            };

            Assert.ThrowsAsync<BadRequestException>(async () => student = await StudentService.Create(student));
        }

        [Test, Order(5)]
        public void Should_Not_Create_With_Inexistent_Course()
        {
            Student student = new Student 
            {
                AcademicRecord = _academicRecord,
                Name = "Jonathan Silva",
                CourseId = MockedCourses.FirstOrDefault().CourseId * 100,
                Period = 6,
                Picture = @"\\vmtst\img.png"
            };

            Assert.ThrowsAsync<BadRequestException>(async () => student = await StudentService.Create(student));
        }

        [Test, Order(6)]
        public void Should_Not_Delete_Inexistent()
        {
            bool isSuccess;
            Assert.ThrowsAsync<NotFoundException>(async () => isSuccess = await StudentService.Delete(Guid.NewGuid().ToString()));
        }

        [Test, Order(7)]
        public void Should_Throw_Not_Found()
        {
            Student student;
            Assert.ThrowsAsync<NotFoundException>(async () => student = await StudentService.Find(Guid.NewGuid().ToString()));
        }

        [Test, Order(8)]
        public void Should_Create()
        {
            _academicRecord = Guid.NewGuid().ToString();

            Student student = new Student 
            {
                AcademicRecord = _academicRecord,
                Name = "Jonathan Silva",
                CourseId = MockedCourses.FirstOrDefault().CourseId,
                Period = 5,
                Picture = @"\\vmtst\img.png"
            };

            Student createdStudent = StudentService.Create(student).Result;

            Assert.IsNotNull(createdStudent);
            Assert.IsInstanceOf(typeof(Student), createdStudent);
        }

        [Test, Order(9)]
        public void Should_Exists()
        {
            Student createdStudent = StudentService.Find(_academicRecord).Result.DeepCopy();

            Assert.IsInstanceOf(typeof(Student), createdStudent);
            Assert.AreEqual(createdStudent.Name, "Jonathan Silva");
        }

        [Test, Order(10)]
        public void Should_Update()
        {
            Student createdStudent = StudentService.Find(_academicRecord).Result.DeepCopy();
            createdStudent.Name = "Johnathan Silveira";
            createdStudent.Period = 4;

            bool isSuccess = StudentService.Update(createdStudent).Result;

            Assert.IsTrue(isSuccess);
        }

        [Test, Order(11)]
        public void Should_Have_Been_Updated()
        {
            Student createdStudent = StudentService.Find(_academicRecord).Result.DeepCopy();

            Assert.AreEqual(createdStudent.Period, 4);
            Assert.AreEqual(createdStudent.Name, "Johnathan Silveira");
        }

        [Test, Order(12)]
        public void Should_Delete_Created()
        {
            bool isSuccess = StudentService.Delete(_academicRecord).Result;

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

        public void MockData()
        {
            MockSubjects();
        }

        public void MockSubjects()
        {
            ISubjectService service = new SubjectService(DbContext);

            List<Subject> subjects = service.CreateMany(new List<Subject>
                                                    {
                                                        new Subject { Name = "Matemática", PassingScore = 6 },
                                                        new Subject { Name = "Português", PassingScore = 6.5 },
                                                        new Subject { Name = "Contabilidade", PassingScore = 6 },
                                                        new Subject { Name = "Cálculo I", PassingScore = 7 },
                                                        new Subject { Name = "Cálculo II", PassingScore = 6.5 },
                                                        new Subject { Name = "Cálculo III", PassingScore = 6.5 },
                                                        new Subject { Name = "Introdução a Banco de dados", PassingScore = 6.5 },
                                                    }).Result;

            MockCourses(subjects, service);
        }

        public void MockCourses(List<Subject> subjects, ISubjectService subjectService)
        {
            #region Inicialização dos objetos
            
            List<Course> coursesToBeCreated = new List<Course>();            
            
            MockedCourses = new List<Course>();

            ICourseService service = new CourseService(DbContext,
                                new CourseSubjectService(DbContext,
                                    subjectService));
            #endregion

            #region Cursos a serem criados

            coursesToBeCreated.Add(new Course
            {
                Name = "Análise e desenvolvimento de sistemas",
                Subjects = new List<Subject>
                {
                    subjects.ElementAt(0), //Matemática
                    subjects.ElementAt(1), //Português
                    subjects.ElementAt(2), //Contabilidade
                    subjects.ElementAt(3), //Calculo 1
                    subjects.ElementAt(6)  //BD
                }
            });

            coursesToBeCreated.Add(new Course
            {
                Name = "Banco de Dados",
                Subjects = new List<Subject>
                {
                    subjects.ElementAt(0), //Matemática
                    subjects.ElementAt(1), //Português
                    subjects.ElementAt(3), //Calculo 1
                    subjects.ElementAt(4), //Calculo 2
                    subjects.ElementAt(6)  //BD
                }
            });

            coursesToBeCreated.Add(new Course
            {
                Name = "Logística",
                Subjects = new List<Subject>
                {
                    subjects.ElementAt(0), //Matemática
                    subjects.ElementAt(1), //Português
                    subjects.ElementAt(3), //Calculo 1
                    subjects.ElementAt(4), //Calculo 2
                }
            });
            
            coursesToBeCreated.Add(new Course
            {
                Name = "Matemática",
                Subjects = new List<Subject>
                {
                    subjects.ElementAt(0), //Matemática
                    subjects.ElementAt(1), //Português
                    subjects.ElementAt(3), //Calculo 1
                    subjects.ElementAt(4), //Calculo 2
                    subjects.ElementAt(5), //Calculo 3
                }
            });
            #endregion

            foreach (var course in coursesToBeCreated)
            {
                MockedCourses.Add(service.Create(course).Result);
            }
        }
    }
}
