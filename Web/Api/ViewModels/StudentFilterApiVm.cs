using System;

namespace Web.Api.ViewModels
{
    public class StudentFilterApiVm
    {
        public string Name { get; set; }
        public string Ra { get; set; }
        public string Status { get; set; }
        public Guid? CourseId { get; set; }
    }
}
