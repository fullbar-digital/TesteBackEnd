using System.Collections.Generic;

namespace Web.Api.ViewModels
{
    public class CourseAddApiVm
    {
        public string Name { get; set; }

        public List<CourseAddSubjectApiVm> Subjects { get; set; }
    }

    public class CourseAddSubjectApiVm
    {
        public string Name { get; set; }

        public decimal MinimumApprovalGrade { get; set; }
    }
}
