using System.Collections.Generic;
using System.Linq;

namespace TesteFullBar.Domain.Models
{
    public class Aluno
    {
        public Aluno()
        {
            AlunoDisciplinas = new HashSet<AlunoDisciplina>();
        }        

        public int Id { get; set; }
        public string Nome { get; set; }

        public string RA { get; set; }

        public string Periodo { get; set; }

        public string Status { get; private set; }

        public string FotoNome { get; set; }

        public byte[] Foto { get; set; }

        public int CursoId { get; set; }

        public virtual Curso Curso { get; set; }

        public ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; }

        public void SetDisciplinas(List<AlunoDisciplina> disciplinas)
        {
            AlunoDisciplinas = disciplinas;
        }

        public void SetStatus(IEnumerable<Disciplina> disciplinas)
        {
            Status = "Aprovado";

            if (disciplinas.Any(n => AlunoDisciplinas.Any(a => a.DisciplinaId == n.Id && a.Nota < n.NotaMinima)))
            {
                Status = "Reprovado";
            }
        }
    }
}
