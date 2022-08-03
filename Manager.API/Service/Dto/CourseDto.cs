using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class CourseDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public List<int> CodeSubject { get; set; }
        public List<CourseSubjectDto> CourseSubjectDto { get; set; }
        public CourseDto() { }

        public CourseDto(int code, string name, List<int> Codesubject, List<CourseSubjectDto> coursesubject)
        {
            Code = code;
            Name = name;
            CodeSubject = Codesubject;
            CourseSubjectDto = coursesubject;
        }
    }
}
