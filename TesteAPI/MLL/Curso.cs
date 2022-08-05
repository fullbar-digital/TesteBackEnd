using System;
using System.Collections.Generic;

namespace TesteAPI.MLL
{
    public class Curso
    {

        public Curso()
        {
            Disciplinas = new List<Disciplina>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }

        public virtual IList<Disciplina> Disciplinas { get; set; }

        internal Curso FirstOrDefault()
        {
            throw new NotImplementedException();
        }

        //public int UsuarioCriacaoCodigo { get; set; }
        //public virtual Usuario Usuario_Criacao { get; set; }
        //public DateTime Data_Criacao { get; set; }
        //public int UsuarioEdicaoCodigo { get; set; }
        //public virtual Usuario Usuario_Edicao { get; set; }
        //public DateTime Data_Edicao { get; set; }
    }
}
