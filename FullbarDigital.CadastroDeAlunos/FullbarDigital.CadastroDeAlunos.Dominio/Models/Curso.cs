using System;
using System.Collections.Generic;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dominio.Models
{
    public class Curso : Model
    {
        public string NomeCurso { get; set; }
        public virtual List<Diciplina> Diciplinas { get; set; }
    }
}
