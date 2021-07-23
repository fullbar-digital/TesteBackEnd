using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAlunos.Business.Models.Response
{
    public class DisciplinaResponse
    {
        public Guid Id { get; set; }

        public double NotaAluno { get; set; }

        public string Status { get; set; }
    }
}
