using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SchoolReport : EntityBase
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Grade { get; set; }


        public Student Student { get; set; }
        public Subject Subject { get; set; }


    }
}
