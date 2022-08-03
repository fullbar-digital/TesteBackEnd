using Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStudentSer
    {
        Task<StudentDto> Create(StudentDto studentDto);
        Task<StudentDto> Update(StudentDto studentDto);
        Task Remove(int code);
        Task<GetStudentDto> Get(int code);
        Task<List<StudentDto>> Get();
        Task<StudentSubjectDto> AddSubject(StudentSubjectDto studentDto);
        Task<List<GetStudentDto>> ListForName(string name);
        Task<GetStudentDto> ListForRA(string RA);
        Task<List<GetStudentDto>> ListForStatus(string status);
        Task<List<GetStudentDto>> ListForCourse(string courseName);
        Task<StudentSubjectDto> AddNote(StudentSubjectDto studentDto);
    }
}
