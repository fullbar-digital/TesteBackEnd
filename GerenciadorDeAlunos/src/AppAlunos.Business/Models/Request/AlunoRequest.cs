using AppAlunos.Business.Models.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppAlunos.Api.Models.Request
{
    public class AlunoRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string RegistroAcademico { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(9, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Periodo { get; set; }


        public string Foto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string NomeCurso { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public List<AlunoDisciplinaRequest> DadosDisciplinas { get; set; }

    }
}
