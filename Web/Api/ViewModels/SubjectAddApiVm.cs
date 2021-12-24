using System;

namespace Web.Api.ViewModels
{
    public class SubjectAddApiVm
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }

        public decimal MinimumApprovalGrade { get; set; }
    }
}
