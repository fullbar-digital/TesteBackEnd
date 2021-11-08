using System.ComponentModel.DataAnnotations;

namespace TesteBackend.WebApi.Dtos.DisciplinaDtos
{
    /// <summary>
    /// Modelo para cadastro da disciplina
    /// </summary>
    public class DisciplinaCreateDto
    {
        /// <summary>
        /// Nome da disciplina
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "O nome da disciplina não pode ser vazio")]
        public string Nome { get; set; }

        /// <summary>
        /// Identificador do curso
        /// </summary>
        [Required(ErrorMessage = "O código do curso é obrigatório")]
        public int CursoId { get; set; }
    }
}
