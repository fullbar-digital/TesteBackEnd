namespace TesteBackend.WebApi.Dtos.DisciplinaDtos
{
    /// <summary>
    /// Modelo dos dados da disciplina para exibição
    /// </summary>
    public class DisciplinaDto
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
    }
}
