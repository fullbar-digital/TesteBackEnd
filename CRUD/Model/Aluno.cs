using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Model
{
    [TableAttribute("Aluno")]
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string RA { get; set; }

        public int Periodo { get; set; }

        public string Curso { get; set; }

        public int Nota { get; set; }

        public string status
        {
            get
            {
                return Nota > 7 ? "aprovado" : "reprovado";
            }
        }

    }
}
