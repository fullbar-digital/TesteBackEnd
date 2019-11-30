using Microsoft.AspNetCore.Mvc;
using StudentRegistration.WebApp.Business;
using StudentRegistration.WebApp.Models.ViewModels;
using StudentRegistration.WebApp.Repository;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StudentRegistration.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient _client = new HttpClient();

        private StudentRepository Repository(HttpClient _client)
        {
            return new StudentRepository(_client);
        }

        public StudentController()
        {
            _client.BaseAddress = new Uri("https://localhost:44312/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> Index()
        {
            var modelList = await new StudentBusiness(Repository(_client)).GetStudents();

            return View(modelList);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = await new StudentBusiness(Repository(_client)).GetStudent(id);

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var model = new StudentViewModel();
            model.StudentPeriods = new StudentBusiness(Repository(_client)).GetPeriods();
            model.StudentCourses = await new StudentBusiness(Repository(_client)).GetCourses();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentViewModel model)
        {
            try
            {
                model = await new StudentBusiness(Repository(_client)).PostStudent(model);

                return RedirectToAction("Details", model);
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = await new StudentBusiness(Repository(_client)).GetStudent(id);
            model.StudentPeriods = new StudentBusiness(Repository(_client)).GetPeriods();
            model.StudentCourses = await new StudentBusiness(Repository(_client)).GetCourses();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentViewModel model)
        {
            try
            {
                var response = await new StudentBusiness(Repository(_client)).PutStudent(id, model);

                if (response)
                {
                    return RedirectToAction("Details", model);
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await new StudentBusiness(Repository(_client)).DeleteStudent(id);

                if (response)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}