using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.AlunosAPI.Data.ValueObject
{
    public class AlunoVO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
      
        public decimal Ra { get; set; }
        
        public string Periodo { get; set; }
      
        public string Curso { get; set; }
      
        public string Status { get; set; }
      
        public string Foto { get; set; }
    }
}
