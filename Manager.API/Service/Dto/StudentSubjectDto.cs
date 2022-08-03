using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class StudentSubjectDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal Note { get; set; }
        public string Status { get; set; }

        public StudentSubjectDto() { }

        public StudentSubjectDto(int studentid, int subjectid, decimal note, string status)
        {
            StudentId = studentid;
            SubjectId = subjectid;
            Note = note;
            Status = status;
        }
        public StudentSubjectDto(int studentid, int subjectid, decimal note)
        {
            StudentId = studentid;
            SubjectId = subjectid;
            Note = note;
        }
    }
}
