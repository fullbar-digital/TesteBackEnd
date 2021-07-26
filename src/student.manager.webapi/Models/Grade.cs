using System;
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
        public long GradeId { get; internal set; }
                
        [Required]
        [JsonProperty("RA")]
        public string AcademicRecord { get; set; }

        [JsonIgnore]
        internal Student Student { get; set; }
        
        [Required]
        public long SubjectId { get; set; }

        [JsonIgnore]
        internal Subject Subject { get; set; }
        
        [Required]
        public double Value { get; set; }
        
        /// <summary>
        /// Cria uma cópia que evita que as alterações feitas no objeto sejam refletidas direto no banco de dados
        /// </summary>        
        public Grade DeepCopy()
        {
            return (Grade)MemberwiseClone();
        }
    }
}
