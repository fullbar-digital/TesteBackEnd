using System;

namespace Fullbar.Teste.Domain.Entities
{
    public class Aluno : Entity
    {
        public Guid CursoId { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
        public Periodo Periodo { get; set; }
        public bool Status { get; set; }
        public string Foto { get; set; }

        public Curso Curso { get; set; }
    }
}