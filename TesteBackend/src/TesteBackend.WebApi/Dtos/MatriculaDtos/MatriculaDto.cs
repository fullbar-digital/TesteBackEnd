using TesteBackend.Domain.Models;

namespace TesteBackend.WebApi.Dtos.DisciplinaDtos
{
    /// <summary>
    /// Modelo para exibição dos dados de matrícula
    /// </summary>
    public class MatriculaDto
    {
        /// <summary>
        /// Disciplina da matrícula
        /// </summary>
        public virtual DisciplinaDto Disciplina { get; set; }

        /// <summary>
        /// Nota do aluno
        /// </summary>
        public decimal Nota { get; set; }

        /// <summary>
        /// Status na matrícula na disciplina
        /// </summary>
        public StatusResult Status { get; private set; }
    }
}
