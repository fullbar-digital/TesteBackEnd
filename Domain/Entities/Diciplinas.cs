using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Diciplinas : IEntity
    {
        public int Id { get; set; }
        public string nomeDiciplina { get; set; }
        [Required]
        public Double notaMinimaAprovacao { get; set; }
    }
}
