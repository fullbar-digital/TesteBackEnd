using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Api.ApplicationCore.Entities
{
    [Table("student", Schema = "dbo")]
    public class StudentBase
    {
        public string Name { get; set; }
        public string RA { get; set; }
        public int Period { get; set; }
        public string Photo { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public bool Status { get; set; }
    }
}