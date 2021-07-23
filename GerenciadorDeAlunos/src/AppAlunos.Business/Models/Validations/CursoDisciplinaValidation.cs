using AppAlunos.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace AppAlunos.Business.Models.Validations
{
    public class CursoDisciplinaValidation
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CursoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Curso Curso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid DisciplinaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Disciplina Disciplina { get; set; }

    }
}
