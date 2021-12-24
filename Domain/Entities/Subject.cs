using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Subject : EntityBase
    {
        public string Name { get; set; }
        public Guid CourseId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal MinimumApprovalGrade { get; set; }

        public Course Course { get; set; }

        public List<SchoolReport> SchoolReports { get; set; }

    }
}
