using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AppAlunos.Api.DTO
{
    public class CursoDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar as disciplinas que serão cadastradas no curso")]
        public IEnumerable<string> DisciplinasDoCurso{ get; set; }
    }
}
