using Teste.Domain.Common.Entities;
using Teste.Domain.Cursos.Entitites;

namespace Teste.Domain.Alunos.Entities
{
    public class Aluno : BaseEntity
    {
        private int status;


        public string Nome { get; set; } = default!;
        public string RA { get; set; } = default!;
        public int Periodo { get; set; }
        public Guid CursoId { get; set; }
        public virtual Curso Curso { get; set; } = default!;
        public int Status
        {
            get { return status; }
        }
        public string Foto { get; set; } = default!;
    }
}
