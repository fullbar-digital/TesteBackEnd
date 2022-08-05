using System;

namespace TesteAPI.MLL
{
    public class AlunoNota
    {
        public int Codigo { get; set; }
        public int AlunoCodigo { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int DisciplinaCodigo { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public decimal Nota { get; set; }

        //public int UsuarioCriacaoCodigo { get; set; }
        //public virtual Usuario Usuario_Criacao { get; set; }
        //public DateTime Data_Criacao { get; set; }
        //public int UsuarioEdicaoCodigo { get; set; }
        //public virtual Usuario Usuario_Edicao { get; set; }
        //public DateTime Data_Edicao { get; set; }
    }
}
