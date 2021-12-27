using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel.Disciplina
{
    public class AlunoDisciplinaVM
    {
        public int AlunoCodigo { get; set; }
        public int DisciplinaCodigo { get; set; }
        public float Nota { get; set; }

        public AlunoDisciplinaVM(){}

        public AlunoDisciplinaVM(int alunoCodigo, int disciplinaCodigo, float nota)
        {
            AlunoCodigo = alunoCodigo;
            DisciplinaCodigo = disciplinaCodigo;
            Nota = nota;
        }
    }
}
