using System;

namespace Web.Api.ViewModels
{
    public class SubjectApivm
    {
        public string Name { get; set; }

        public decimal MinimumApprovalGrade { get; set; }
        public Guid Id { get; set; }
    }
}
