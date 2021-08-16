using System;
using System.Collections.Generic;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dominio.Models
{
    public class Aluno : Model
    {
        public long CursoId { get; set; }
        public string Nome { get; set; }
        public string Ra { get; set; }
        public string Periodo { get; set; }
        public string Curso { get; set; }
        public string Status { get; set; }
        public string Foto { get; set; }
        public virtual Curso AlunoCurso { get; set; }
        public virtual List<Historico> Historicos { get; set; }
    }
}
