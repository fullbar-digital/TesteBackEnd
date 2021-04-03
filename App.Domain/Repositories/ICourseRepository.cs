using System;
using System.Collections.Generic;
using App.Domain.Models;

namespace App.Domain.Repositories
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
    }
}