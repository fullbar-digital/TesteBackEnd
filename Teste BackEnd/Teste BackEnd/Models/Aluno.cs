using System.ComponentModel.DataAnnotations;

namespace Teste_BackEnd.Models
{
    public class Aluno : BaseModel
    {
        [Required]
        public string RA { get; set; }
        [Required]
        public string Periodo { get; set; }
        public int CursoId { get; set; }
        [Required]
        public Curso Curso { get; set; }
        public string Status { get; set; }
        public string Foto { get; set; }
    }
}
