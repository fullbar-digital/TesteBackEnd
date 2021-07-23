using System.ComponentModel.DataAnnotations;

namespace AppAlunos.Business.Models.Request
{
    public class AlunoDisciplinaRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string NomeDisciplina { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double NotaDaDisciplina { get; set; }
    }
}
