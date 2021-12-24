using System;
using System.Collections.Generic;

namespace Web.Api.ViewModels
{
    public class StudentAddApiVm
    {
        public string Name { get;  set; }
        public string Ra { get;  set; }
        public int Period { get;  set; }
        public string ProfilePicture { get;  set; }

        public Guid CourseId { get; set; }

        public List<StudentAddSubjectApivm> Subjects { get; set; }
    }

    public class StudentAddSubjectApivm
    {
        public decimal Grade { get; set; }
        public Guid Id { get; set; }
    }
}
