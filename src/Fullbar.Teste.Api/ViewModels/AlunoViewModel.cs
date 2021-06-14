using System;
using System.ComponentModel.DataAnnotations;

namespace Fullbar.Teste.Api.ViewModels
{
    public class AlunoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CursoId { get; set; }
        public string FotoUpload { get; set; }
        public string Foto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; set; }
        public string RA { get; set; }
        public int Periodo { get; set; }
        public bool Status { get; set; }
    }
}
