using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteFullBar.Domain.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        {
            
        }

        [Key, Column(Order = 1)]
        public int AlunoId { get; set; }
        [Key, Column(Order = 2)]
        public int DisciplinaId { get; set; }

        [Column(TypeName = "decimal(2, 2)")]
        public decimal Nota { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Disciplina Disciplina { get; set; }
    }
}
