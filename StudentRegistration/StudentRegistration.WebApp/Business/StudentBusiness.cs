using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StudentRegistration.WebApi.Models;
using StudentRegistration.WebApp.Models;
using StudentRegistration.WebApp.Models.ViewModels;
using StudentRegistration.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.WebApp.Business
{
    public class StudentBusiness
    {
        private readonly StudentRepository _repository;

        public StudentBusiness(StudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentViewModel> GetStudent(int id)
        {
            var response = JsonConvert.DeserializeObject<Student>
                (await _repository.GetStudent(id));

            var model = MapperToView().Map<Student, StudentViewModel>(response);

            return await GetDisplay(model);
        }

        public async Task<IEnumerable<StudentViewModel>> GetStudents()
        {
            var response = JsonConvert.DeserializeObject<IEnumerable<Student>>
                (await _repository.GetStudents());

            var modelList = MapperToView().Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(response).ToList();

            var modelListDisplay = new List<StudentViewModel>();

            foreach (var model in modelList)
            {
                modelListDisplay.Add(await GetDisplay(model));
            }

            return modelListDisplay;
        }

        public async Task<StudentViewModel> PostStudent(StudentViewModel model)
        {
            model.Status = DoStatus(model.Grade);

            var student = MapperFromView().Map<StudentViewModel, Student>(model);

            var response = JsonConvert.DeserializeObject<Student>
                (await _repository.PostStudent(ToStringContent(student)));

            return MapperToView().Map<Student, StudentViewModel>(response);
        }

        public async Task<bool> PutStudent(int id, StudentViewModel model)
        {
            model.Status = DoStatus(model.Grade);

            var student = MapperFromView().Map<StudentViewModel, Student>(model);

            return await _repository.PutStudent(id, ToStringContent(student));
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _repository.DeleteStudent(id);
        }

        private int DoStatus(double grade)
        {
            return grade > 7 ? 2 : 1;
        }

        public SelectList GetPeriods()
        {
            var modelList = new List<SelectListItem>();

            foreach (var period in Enum.GetValues(typeof(EnumCollection.Period)))
            {
                modelList.Add(new SelectListItem()
                {
                    Text = period.ToString(),
                    Value = ((int)Enum.Parse(typeof(EnumCollection.Period), period.ToString())).ToString()
                });
            }

            return new SelectList(modelList, "Value", "Text");
        }

        public async Task<SelectList> GetCourses()
        {
            var modelList = new List<SelectListItem>();

            var response = JsonConvert.DeserializeObject<List<Course>>
                (await _repository.GetCourses());

            (from course in response select course)
                .ToList()
                .ForEach(x => modelList.Add(new SelectListItem()
                {
                    Value = x.ID.ToString(),
                    Text = x.Option
                }));

            return new SelectList(modelList, "Value", "Text");
        }

        private async Task<StudentViewModel> GetDisplay(StudentViewModel model)
        {
            var coursesResponse = JsonConvert.DeserializeObject<List<Course>>
                (await _repository.GetCourses());

            model.DisplayCourse = coursesResponse.First(x => x.ID == model.Course).Option;
            model.DisplayPeriod = ((EnumCollection.Period)model.Period).ToString();
            model.DisplayStatus = ((EnumCollection.Status)model.Status).ToString();

            return model;
        }

        public StringContent ToStringContent(Student student)
        {
            var studentContent = JsonConvert.SerializeObject(student);

            return new StringContent(studentContent, UnicodeEncoding.UTF8, "application/json");
        }

        public Mapper MapperToView()
        {
            return new Mapper(new MapperConfiguration(x => x
            .CreateMap<Student, StudentViewModel>()));
        }

        public Mapper MapperFromView()
        {
            return new Mapper(new MapperConfiguration(x => x
            .CreateMap<StudentViewModel, Student>()));
        }
    }
}
