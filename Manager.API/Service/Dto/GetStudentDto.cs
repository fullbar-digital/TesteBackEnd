using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class GetStudentDto
    {
        public string Name { get; set; }
        public string RA { get; set; }
        public string Turn { get; set; }
        public string Picture { get; set; }
        public CourseDto Course { get; set; }
        public IList<GetStudentSubjectDto> Subjects { get; set; }

        public GetStudentDto() { }

        public GetStudentDto(string name, string rA, string turn, string picture)
        {
            Name = name;
            RA = rA;
            Turn = turn;
            Picture = picture;
        }

        public GetStudentDto(string name, string rA, string turn, string picture, DateTime? createdate, CourseDto course, IList<GetStudentSubjectDto> subjects)
        {
            Name = name;
            RA = rA;
            Turn = turn;
            Picture = picture;
            Course = course;
            Subjects = subjects;
        }
    }
}
