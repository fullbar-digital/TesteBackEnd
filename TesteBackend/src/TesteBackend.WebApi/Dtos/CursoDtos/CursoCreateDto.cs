using System.ComponentModel.DataAnnotations;

namespace TesteBackend.WebApi.Dtos.CursoDtos
{
    /// <summary>
    /// Entidade para cadastro do curso
    /// </summary>
    public class CursoCreateDto
    {
        /// <summary>
        /// Nome do curso
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "O nome do curso não pode ficar vazio")]
        public string Nome { get; set; }
    }
}
