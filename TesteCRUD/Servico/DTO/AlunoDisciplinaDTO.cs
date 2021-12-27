using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servico.DTO
{
    public class AlunoDisciplinaDTO
    {
        public int AlunoCodigo { get; set; }
        public int DisciplinaCodigo { get; set; }
        public decimal Nota { get; set; }
        public string Status { get; set; }

        public AlunoDisciplinaDTO(){}

        public AlunoDisciplinaDTO(int alunoCodigo, int disciplinaCodigo, decimal nota, string status)
        {
            AlunoCodigo = alunoCodigo;
            DisciplinaCodigo = disciplinaCodigo;
            Nota = nota;
            Status = status;
        }
        public AlunoDisciplinaDTO(int alunoCodigo, int disciplinaCodigo, decimal nota)
        {
            AlunoCodigo = alunoCodigo;
            DisciplinaCodigo = disciplinaCodigo;
            Nota = nota;
        }
    }
}
