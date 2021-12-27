using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel.Aluno
{
    public class CriarAlunoVM
    {
        public string Nome { get; set; }
        public string RA { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }
        public int CursoCodigo { get; set; }
        public CriarAlunoVM() {}
        public CriarAlunoVM(string nome, string rA, string periodo, string foto, int codigoCurso)
        {
            Nome = nome;
            RA = rA;
            Periodo = periodo;
            CursoCodigo = codigoCurso;
        }

    }
}
