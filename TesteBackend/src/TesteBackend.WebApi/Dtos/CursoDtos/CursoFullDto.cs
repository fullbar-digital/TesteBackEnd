using System.Collections.Generic;
using TesteBackend.WebApi.Dtos.DisciplinaDtos;

namespace TesteBackend.WebApi.Dtos
{
    /// <summary>
    /// Modelo com dados do curso
    /// </summary>
    public class CursoFullDto
    {
        /// <summary>
        /// Identificador do curso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do curso
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Relação de disciplinas do curso
        /// </summary>
        public virtual ICollection<DisciplinaDto> Disciplinas { get; set; }
    }
}
