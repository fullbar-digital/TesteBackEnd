using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

using Repositories;

using System.Diagnostics;
using System.Linq;

using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InitDb()
        {
            var bga = new Course();
            bga.Name = "Bacharelado em Gestão Ambiental";

            var fm = new Subject();
            fm.Name = "Fundamentos de Matemática";
            fm.MinimumApprovalGrade = 7.0m;

            var bg = new Subject();
            bg.Name = "Biologia Geral";
            bg.MinimumApprovalGrade = 7.0m;

            var fe = new Subject();
            fe.Name = "Fundamentos de Ecologia";
            fe.MinimumApprovalGrade = 7.0m;

            bga.Subjects.Add(fm);
            bga.Subjects.Add(bg);
            bga.Subjects.Add(fe);

            var existsCourse = _unitOfWork.CourseRepository
                .Where(a => a.Name.Equals(bga.Name), CollectionPaths: new[] { "Subjects" })
                .FirstOrDefault();
            if (existsCourse == null)
            {
                _unitOfWork.CourseRepository.Add(bga);
                _unitOfWork.Commit();
                existsCourse = bga;
            }

            var std = new Student();
            std.Name = "Jhonatas Lima";
            std.Ra = "RA202100001";
            std.Period = 1;
            std.CourseId = bga.Id;
            std.ProfilePicture = "https://dorinapdf.azurewebsites.net/img/1586624207425.jfif";

            var existsStudent = _unitOfWork.StudentRepository.Where(a => a.Name.Equals(std.Name)).FirstOrDefault();
            if (existsStudent == null)
            {
                _unitOfWork.StudentRepository.Add(std);
                _unitOfWork.Commit();
                existsStudent = std;
            }

            foreach (var subject in existsCourse.Subjects)
            {
                _unitOfWork.SchoolReportRepository.AddOrUpdateReport(existsStudent.Id, subject.Id, 8.0m);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
