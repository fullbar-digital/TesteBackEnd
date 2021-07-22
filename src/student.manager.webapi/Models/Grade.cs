﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace student.manager.webapi.Models
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GradeId { get; set; }

        public long CourseId { get; set; }
        
        [JsonIgnore]
        public Course Course { get; set; }
        
        [JsonProperty("RA")]
        public string AcademicRecord { get; set; }

        public long SubjectId { get; set; }

        public double Value { get; set; }
    }
}
