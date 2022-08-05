using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCadastro.Dominio.Entity
{
    public class Alunos
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Decimal Ra { get; set; }
        public string Periodo { get; set; }
        public string Curso { get; set; }
        public string Status { get; set; }
        public string Foto { get; set; }

    }
}
