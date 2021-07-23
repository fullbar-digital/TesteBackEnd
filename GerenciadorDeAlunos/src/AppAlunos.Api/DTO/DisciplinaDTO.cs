using System;
using System.ComponentModel.DataAnnotations;


namespace AppAlunos.Api.DTO
{
    public class DisciplinaDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double NotaMinimaAprovacao { get; set; }

    }
}
