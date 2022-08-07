using System.ComponentModel.DataAnnotations;

namespace Teste_BackEnd.Models
{
    public class Disciplina : BaseModel
    {
        public int CursoId { get; set; }
        [Required]
        public int NotaMinimaAprovacao { get; set; }
    }
}
