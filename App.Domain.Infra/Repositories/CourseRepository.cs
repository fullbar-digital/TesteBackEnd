using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Infra.Contexts;
using App.Domain.Models;
using App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Domain.Infra.Respositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationContext _appContext;
        public CourseRepository(ApplicationContext AppContext)
        {
            _appContext = AppContext;
        }

        public void AddCourse(Course course)
        {
            _appContext.courses.Add(course);
            _appContext.SaveChanges();

        }
    }
}