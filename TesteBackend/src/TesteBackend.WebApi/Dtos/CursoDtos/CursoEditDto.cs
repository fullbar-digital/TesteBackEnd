using System.ComponentModel.DataAnnotations;

namespace TesteBackend.WebApi.Dtos.CursoDtos
{
    /// <summary>
    /// Modelo para edição do curso
    /// </summary>
    public class CursoEditDto
    {
        /// <summary>
        /// Identificador do curso
        /// </summary>
        [Required(ErrorMessage = "O código do curso é obrigatório")]
        public int Id { get; set; }

        /// <summary>
        /// Nome do curso
        /// </summary>
        [Required(ErrorMessage = "O nome do curso não pode ser vazio")]
        [MinLength(1)]
        public string Nome { get; set; }
    }
}
