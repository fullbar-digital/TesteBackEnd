using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class CourseSubjectDto
    {
        public int CourseCode { get; set; }
        public int SubjectCode { get; set; }

        public CourseSubjectDto(int coursecode, int subjectcode)
        {
            CourseCode = coursecode;
            SubjectCode = subjectcode;
        }
    }
}
