using Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICourseSer
    {
        Task<CourseDto> Create(CourseDto courseDTO);
        Task<CourseDto> Update(CourseDto courseDTO);
        Task Remove(int code);
        Task<CourseDto> Get(int code);
        Task<List<CourseDto>> Get();
        Task<CourseSubjectDto> AddSubject(CourseSubjectDto coursesubjectDTO);
        Task DeleteSubject(CourseSubjectDto coursesubjectDTO);
    }
}
