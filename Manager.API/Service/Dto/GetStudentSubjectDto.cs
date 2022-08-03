using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class GetStudentSubjectDto
    {
        public string SubjectName { get; set; }
        public int ApproveMin { get; set; }
        public decimal Note { get; set; }
        public string Status { get; set; }

        public GetStudentSubjectDto() { }
        public GetStudentSubjectDto(decimal note, string status)
        {
            Note = note;
            Status = status;
        }
        public GetStudentSubjectDto(string name, int approvemin, decimal note, string status)
        {
            SubjectName = name;
            ApproveMin = approvemin;
            Note = note;
            Status = status;
        }
    }
}
