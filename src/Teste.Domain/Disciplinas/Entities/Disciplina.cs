using Teste.Domain.Common.Entities;
using Teste.Domain.Cursos.Entitites;

namespace Teste.Domain.Disciplinas.Entities
{
    public class Disciplina : BaseEntity
    {
        public string Nome { get; set; } = default!;
        public decimal NotaMinimaAprovacao { get; set; }
        public Guid CursoId { get; set; }
        public virtual Curso Curso { get; set; } = default!;
    }
}
