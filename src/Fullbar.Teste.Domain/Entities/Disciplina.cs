using System;

namespace Fullbar.Teste.Domain.Entities
{
    public class Disciplina : Entity
    {
        public Guid CursoId { get; set; }
        public string Nome { get; set; }
        public decimal NotaMinima { get; set; }
        public Curso Curso { get; set; }
    }
}
