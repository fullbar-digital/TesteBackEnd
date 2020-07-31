using ApplicationCore.Domain.Repositories;
using Moq;
using System;
using System.Threading.Tasks;
using ApplicationCore.Domain.Component;
using Xunit;

namespace Tests.Student
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _studentRepository;

        public StudentServiceTests()
        {
            _studentRepository = new Mock<IStudentRepository>();
        }

        private ApplicationCore.Domain.Student Get(int id) => new ApplicationCore.Domain.Student(id, 4, "Flavio",
            "102030", new Period {Start = DateTime.Now, End = DateTime.Now.AddYears(1)}, 8, true);

        [Fact]
        public async Task Deve_Criar_Aluno()
        {
            var student = new ApplicationCore.Domain.Student
            {
                CourseId = 4,
                Name = "Flavio",
                Ra = "102030",
                Grade = 8,
                Period = new Period { Start = DateTime.Now, End = DateTime.Now.AddYears(1) },
                Status = true
            };

            var studentService = new StudentService(_studentRepository.Object);

            await studentService.Save(student);

            _studentRepository.Verify(x => x.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Deve_Alterar_Aluno()
        {
            _studentRepository.Setup(x => x.Find(It.IsAny<int>()))
                .Returns(Task.FromResult(Get(1)));

            _studentRepository.Setup(x => x.Update(It.IsAny<ApplicationCore.Domain.Student>()))
                .Returns(Task.CompletedTask);

            var period = new Period { Start = DateTime.Now, End = DateTime.Now.AddYears(1) };
            var student = new ApplicationCore.Domain.Student { Id = 1, Name = "Flavio Macias", Ra = "1075", Period = period, CourseId = 2, Grade = 6 };

            var studentService = new StudentService(_studentRepository.Object);

            await studentService.Update(student);

            _studentRepository.Verify(x => x.Find(1), Times.Once);
            _studentRepository.Verify(x => x.Update(student), Times.Once);
            _studentRepository.Verify(x => x.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task Deve_Excluir_Aluno()
        {
            _studentRepository.Setup(x => x.Delete(It.IsAny<ApplicationCore.Domain.Student>()))
                .Returns(Task.CompletedTask);

            _studentRepository.Setup(x => x.Find(It.IsAny<int>()))
                .Returns(Task.FromResult(Get(1)));

            var studentService = new StudentService(_studentRepository.Object);

            await studentService.Delete(1);

            _studentRepository.Verify(x => x.Delete(Get(1)), Times.Once);
            _studentRepository.Verify(x => x.Find(1), Times.Once);
            _studentRepository.Verify(x => x.CommitAsync(), Times.Once);
        }
    }
}
