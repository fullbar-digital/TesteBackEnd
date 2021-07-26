using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.manager.webapi.Models
{
    [Table("CourseSubject")]
    public class CourseSubject
    {
        [Required]
        public long CourseId { get; set; }
        [Required]
        public long SubjectId { get; set; }

        [JsonIgnore]
        internal Course Course { get; set; }

        [JsonIgnore]
        internal Subject Subject { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
