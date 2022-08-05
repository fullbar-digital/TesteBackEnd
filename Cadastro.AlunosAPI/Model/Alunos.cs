using Cadastro.AlunosAPI.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.AlunosAPI.Model
{
    [Table("Alunos")]
    
    public class Alunos: BaseEntity
    {
        [Column("name")]
        [Required]
        public string Nome { get; set; }
        [Column("ra")]
        public decimal Ra { get; set; }
        [Column("periodo")]
        public string Periodo { get; set; }
        [Column("curso")]
        public string Curso { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("img_url")]
        public string Foto { get; set; }


    }
}
