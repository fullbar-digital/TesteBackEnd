using System;

namespace TesteAPI.MLL
{
    public class Disciplina
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Nota_Aprovacao { get; set; }
        public int CursoCodigo { get; set; }
        public virtual Curso Curso { get; set; }

        //public int UsuarioCriacaoCodigo { get; set; }
        //public virtual Usuario Usuario_Criacao { get; set; }
        //public DateTime Data_Criacao { get; set; }
        //public int UsuarioEdicaoCodigo { get; set; }
        //public virtual Usuario Usuario_Edicao { get; set; }
        //public DateTime Data_Edicao { get; set; }
    }
}
