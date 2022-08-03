using Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISubjectSer
    {
        Task<SubjectDto> Create(SubjectDto subjectDTO);
        Task<SubjectDto> Update(SubjectDto subjectDTO);
        Task Remove(int code);
        Task<SubjectDto> Get(int code);
        Task<List<SubjectDto>> Get();
    }
}
