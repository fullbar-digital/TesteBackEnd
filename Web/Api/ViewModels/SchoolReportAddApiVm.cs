using System;

namespace Web.Api.ViewModels
{
    public class SchoolReportAddApiVm
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public decimal Grade { get; set; }
    }
}
