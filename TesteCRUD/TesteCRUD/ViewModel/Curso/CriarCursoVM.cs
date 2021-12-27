using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCRUD.ViewModel
{
    public class CriarCursoVM
    {
        public string Nome { get; set; }
        public List<int> CodigoDisciplinas { get; set; }

        public CriarCursoVM(){}

        public CriarCursoVM(string nome, List<int> codigoDisciplinas)
        {
            Nome = nome;
            CodigoDisciplinas = codigoDisciplinas;
        }
    }
}
