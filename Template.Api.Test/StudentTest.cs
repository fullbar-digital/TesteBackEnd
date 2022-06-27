using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.Test
{
    [TestClass]
    public class StudentTest
    {
        private DependencyResolverHelper _serviceProvider;
        private readonly IUnitOfWork _unitOfWork;

        public StudentTest()
        {
            var webHost = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build();

            _serviceProvider = new DependencyResolverHelper(webHost);

            _unitOfWork = _serviceProvider.GetService<IUnitOfWork>();
        }

        [TestMethod("Get all students")]
        public async Task GetStudentsTestAsync()
        {
            var result = await _unitOfWork.Students.GetAllAsync();

            Assert.IsNotNull(result, "Get failed or there's no students in the database.");
        }

        [TestMethod("Get student by id")]
        public async Task GetStudentByIdTestAsync()
        {
            var result = await _unitOfWork.Students.GetByIdAsync(1);

            Assert.IsNotNull(result, "Get failed or there's no students with that id in the database.");
        }

        [TestMethod("Filter student by name")]
        public async Task FilterStudentByNameTestAsync()
        {
            var result = await _unitOfWork.Students.FindAsync(s => s.Name.Contains("Luiz"));

            Assert.IsNotNull(result, "Get failed or there's no students with that name in the database.");
        }

        [TestMethod("Filter student by RA")]
        public async Task FilterStudentByRATestAsync()
        {
            var result = await _unitOfWork.Students.FindAsync(s => s.RA.Contains("123"));

            Assert.IsNotNull(result, "Get failed or there's no students with that RA in the database.");
        }

        [TestMethod("Filter student by course")]
        public async Task FilterStudentByIdCourseAsync()
        {
            var result = await _unitOfWork.Students.FindAsync(s => s.CourseSubjectStudent.Any(x => x.CourseSubject.Course.Name.Contains("Development")));

            Assert.IsNotNull(result, "Get failed or there's no students with that course in the database.");
        }

        [TestMethod("Filter student by status")]
        public async Task FilterStudentByStatusTestAsync()
        {
            var result = await _unitOfWork.Students.FindAsync(s => s.Status.Equals(true));

            Assert.IsNotNull(result, "Get failed or there's no students with that status in the database.");
        }

        [TestMethod("Create student")]
        public async Task CreateStudentTestAsync()
        {
            var result = await _unitOfWork.Students.AddAsync(new ApplicationCore.Entities.Student()
            {
                Name = "Luiz",
                RA = "123",
                Period = 1,
                Photo = "photo",
                Status = true
            });

            Assert.IsTrue(result > 0, "Student creation failed!");
        }

        [TestMethod("Update student")]
        public async Task UpdateStudentTestAsync()
        {
            var result = await _unitOfWork.Students.UpdateAsync(new ApplicationCore.Entities.Student()
            {
                StudentId = 2,
                Name = "Henrique",
                RA = "789",
                Period = 3,
                Photo = "photo 3",
                Status = false //It won't be updated
            });

            Assert.IsTrue(result > 0, "Student update failed");
        }

        [TestMethod("Delete student")]
        public async Task DeleteStudentTestAsync()
        {
            var result = await _unitOfWork.Students.DeleteAsync(3);

            Assert.IsTrue(result > 0, "Student delete failed");
        }
    }
}
