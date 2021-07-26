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
using grade.manager.webapi.Interfaces;

namespace student.manager.test
{
    public class TestGrade
    {
        public DatabaseContext DbContext;
        public static Grade _grade;
        public IGradeService GradeService;
        public List<Student> MockedStudents;

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

            GradeService = new GradeService(DbContext);
            DeleteMockedData();
            MockData();
        }

        [Test, Order(1)]
        public void Should_Not_Create_Without_AcademicRecord()
        {
            Grade grade = new Grade
            {
                SubjectId = MockedStudents.FirstOrDefault().Course.Subjects.FirstOrDefault().SubjectId,
                Value = 5,
            };

            Assert.ThrowsAsync<BadRequestException>((async () => grade = await GradeService.Create(grade)), "O RA não está preenchido./n");
        }

        [Test, Order(2)]
        public void Should_Not_Create_Without_Subject()
        {
            Grade grade = new Grade
            {
                AcademicRecord = MockedStudents.FirstOrDefault().AcademicRecord,
                Value = 5,
            };

            Assert.ThrowsAsync<BadRequestException>((async () => grade = await GradeService.Create(grade)), "O ID da matéria deve ser maior que zero./n");
        }

        [Test, Order(3)]
        public void Should_Not_Create_Without_Value()
        {
            Grade grade = new Grade
            {
                SubjectId = MockedStudents.FirstOrDefault().Course.Subjects.FirstOrDefault().SubjectId,
                AcademicRecord = MockedStudents.FirstOrDefault().AcademicRecord,
                Value = -1
            };

            Assert.ThrowsAsync<BadRequestException>((async () => grade = await GradeService.Create(grade)), "O valor da nota deve ser maior ou igual a zero./n");
        }

        [Test, Order(4)]
        public void Should_Not_Create_With_Invalid_Subject()
        {
            Grade grade = new Grade
            {
                AcademicRecord = MockedStudents.FirstOrDefault().AcademicRecord,
                Value = 5,
                SubjectId = 99999
            };

            Assert.ThrowsAsync<BadRequestException>((async () => grade = await GradeService.Create(grade)), string.Format("Não foi possível encontrar uma matéria com o ID {0}./n", grade.SubjectId));
        }

        [Test, Order(5)]
        public void Should_Not_Create_With_Invalid_AcademicRecord()
        {
            Grade grade = new Grade
            {
                SubjectId = MockedStudents.FirstOrDefault().Course.Subjects.FirstOrDefault().SubjectId,
                Value = 5,
                AcademicRecord = "XXXXXX2144444"
            };

            Assert.ThrowsAsync<BadRequestException>((async () => grade = await GradeService.Create(grade)), string.Format("Não foi possível encontrar um aluno com o RA {0}./n", grade.AcademicRecord));
        }

        [Test, Order(6)]
        public void Should_Not_Delete_Inexistent()
        {
            bool isSuccess;
            Assert.ThrowsAsync<NotFoundException>(async () => isSuccess = await GradeService.Delete(999999));
        }

        [Test, Order(7)]
        public void Should_Not_Exists()
        {
            Grade grade;
            Assert.ThrowsAsync<NotFoundException>(async () => grade = await GradeService.Find(999999));
        }

        [Test, Order(8)]
        public void Should_Create()
        {
            var student = MockedStudents.ElementAt(new Random().Next(0, MockedStudents.Count - 1));
            Grade grade = new Grade
            {
                AcademicRecord = student.AcademicRecord,
                SubjectId = student.Course.Subjects.FirstOrDefault().SubjectId,
                Value = 6,
            };

            _grade = GradeService.Create(grade).Result;

            Assert.IsNotNull(_grade);
            Assert.IsInstanceOf(typeof(Grade), _grade);

            Assert.AreEqual(_grade.AcademicRecord, grade.AcademicRecord);
            Assert.AreEqual(_grade.SubjectId, grade.SubjectId);
            Assert.AreEqual(_grade.Value, grade.Value);
        }

        [Test, Order(9)]
        public void Should_Exists()
        {
            Grade createdGrade = GradeService.Find(_grade.GradeId).Result.DeepCopy();

            Assert.IsNotNull(createdGrade);
            Assert.IsInstanceOf(typeof(Grade), createdGrade);
        }

        [Test, Order(10)]
        public void Should_Update()
        {
            Grade createdGrade = GradeService.Find(_grade.GradeId).Result.DeepCopy();
            createdGrade.Value = 9.25;

            bool isSuccess = GradeService.Update(createdGrade).Result;

            Assert.IsTrue(isSuccess);
        }

        [Test, Order(11)]
        public void Should_Have_Been_Updated()
        {
            Grade createdGrade = GradeService.Find(_grade.GradeId).Result.DeepCopy();

            Assert.AreEqual(createdGrade.Value, 9.25);
        }

        [Test, Order(12)]
        public void Should_Delete_Created()
        {
            bool isSuccess = GradeService.Delete(_grade.GradeId).Result;

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
            #region Setup Services
            ISubjectService subjectService = new SubjectService(DbContext);
            ICourseSubjectService courseSubjectService = new CourseSubjectService(DbContext, subjectService);
            ICourseService courseService = new CourseService(DbContext, courseSubjectService);
            IStudentService studentService = new StudentService(DbContext);
            #endregion

            var createdSubjects =
                MockSubjects(subjectService);
            var createdCourses =
                MockCourses(createdSubjects, courseService);
            MockStudents(createdCourses, studentService);
        }

        public List<Subject> MockSubjects(ISubjectService service)
        {

            return service.CreateMany(new List<Subject>
                                                    {
                                                        new Subject { Name = "Matemática", PassingScore = 6 },
                                                        new Subject { Name = "Português", PassingScore = 6.5 },
                                                        new Subject { Name = "Contabilidade", PassingScore = 6 },
                                                        new Subject { Name = "Cálculo I", PassingScore = 7 },
                                                        new Subject { Name = "Cálculo II", PassingScore = 6.5 },
                                                        new Subject { Name = "Cálculo III", PassingScore = 6.5 },
                                                        new Subject { Name = "Introdução a Banco de dados", PassingScore = 6.5 },
                                                    }).Result;
        }

        public List<Course> MockCourses(List<Subject> subjects, ICourseService service)
        {
            #region Inicialização dos objetos

            List<Course> coursesToBeCreated = new List<Course>();
            List<Course> createdCourses = new List<Course>();

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
                createdCourses.Add(service.Create(course).Result);
            }

            return createdCourses;
        }

        public void MockStudents(List<Course> courses, IStudentService service)
        {
            #region Inicialização dos objetos

            List<Student> studentsToBeCreated = new List<Student>();
            Random random = new Random();
            MockedStudents = new List<Student>();

            #endregion

            #region Estudantes a serem criados

            studentsToBeCreated.Add(new Student
            {
                AcademicRecord = Guid.NewGuid().ToString().Substring(0, random.Next(10, 25)),
                Name = "João Paulo da Silva",
                Period = random.Next(1, 10),
                CourseId = courses.ElementAt(random.Next(0, courses.Count - 1)).CourseId,
                Picture = @"\\external\penguim.png"
            });

            studentsToBeCreated.Add(new Student
            {
                AcademicRecord = Guid.NewGuid().ToString().Substring(0, random.Next(10, 25)),
                Name = "Pedro Pereira Pinto",
                Period = random.Next(1, 10),
                CourseId = courses.ElementAt(random.Next(0, courses.Count - 1)).CourseId,
                Picture = @"\\external\dog.png"
            });

            studentsToBeCreated.Add(new Student
            {
                AcademicRecord = Guid.NewGuid().ToString().Substring(0, random.Next(10, 25)),
                Name = "Ana Maria Braga",
                Period = random.Next(1, 10),
                CourseId = courses.ElementAt(random.Next(0, courses.Count - 1)).CourseId,
                Picture = @"\\external\bird.png"
            });

            studentsToBeCreated.Add(new Student
            {
                AcademicRecord = Guid.NewGuid().ToString().Substring(0, random.Next(10, 25)),
                Name = "Elloyse Grapz",
                Period = random.Next(1, 10),
                CourseId = courses.ElementAt(random.Next(0, courses.Count - 1)).CourseId,
                Picture = @"\\external\toucan.png"
            });

            studentsToBeCreated.Add(new Student
            {
                AcademicRecord = Guid.NewGuid().ToString().Substring(0, random.Next(10, 25)),
                Name = "Maico Diequesson",
                Period = random.Next(1, 10),
                CourseId = courses.ElementAt(random.Next(0, courses.Count - 1)).CourseId,
                Picture = @"\\external\macaw.png"
            });
            #endregion

            foreach (var student in studentsToBeCreated)
            {
                MockedStudents.Add(service.Create(student).Result);
            }
        }
    }
}
