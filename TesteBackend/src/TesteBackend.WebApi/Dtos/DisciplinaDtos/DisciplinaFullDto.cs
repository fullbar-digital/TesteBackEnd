using TesteBackend.WebApi.Dtos.CursoDtos;

namespace TesteBackend.WebApi.Dtos.DisciplinaDtos
{
    /// <summary>
    /// Modelo para exibição dos dados da disciplina
    /// </summary>
    public class DisciplinaFullDto
    {
        /// <summary>
        /// Identificador da disciplina
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da disciplina
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Nota mínima para aprovação
        /// </summary>
        public decimal NotaMinimaAprovacao { get; set; }

        /// <summary>
        /// Curso que a disciplina está vinculada
        /// </summary>
        public virtual CursoDto Curso { get; set; }
    }
}
