using System;
using System.ComponentModel.DataAnnotations;

namespace AppAlunos.Api.DTO
{
    public class AlunoDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string RegistroAcademico { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Foto { get; set; }

        /* Relacionamento */
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CursoId { get; set; }
    }
}
