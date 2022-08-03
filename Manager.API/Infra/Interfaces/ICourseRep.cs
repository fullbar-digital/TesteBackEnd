using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface ICourseRep : IBaseRep<Course>
    {
        Task<List<Course>> CourseForName(string name);
    }
}
