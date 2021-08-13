using System;
using System.Collections.Generic;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dominio.Models
{
    public class Diciplina : Model
    {
        public long IdCurso { get; set; }
        public string NomeDiciplina { get; set; }
        public decimal NotaMinima { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
