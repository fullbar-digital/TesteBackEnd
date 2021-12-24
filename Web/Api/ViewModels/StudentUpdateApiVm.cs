using System;

namespace Web.Api.ViewModels
{
    public class StudentUpdateApiVm
    {
        public Guid? StudentId { get; set; }

        public string Name { get; set; }
        public string Ra { get; set; }
        public int? Period { get; set; }
        public string ProfilePicture { get; set; }

        public Guid? CourseId { get; set; }

    }
}
