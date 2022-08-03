using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class StudentDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string RA { get; set; }
        public string Turn { get; set; }
        public string Picture { get; set; }
        public int CourseId { get; set; }
        public List<StudentSubjectDto> StudentSubjectDto { get; set; }

        public StudentDto() { }

        public StudentDto(int code, string name, string rA, string turn, string picture, int codecourse)
        {
            Code = code;
            Name = name;
            RA = rA;
            Turn = turn;
            Picture = picture;
            CourseId = codecourse;
        }
    }
}
