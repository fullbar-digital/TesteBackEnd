using System;
using System.Collections.Generic;

namespace TesteAPI.MLL
{
    public class Aluno
    {

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Registro_Academico { get; set; }
        public string Periodo { get; set; }
        public int CursoCodigo { get; set; }
        public virtual Curso Curso { get; set; }
        public string Status { get; set; }
        public byte[] Foto { get; set; }
        //public int UsuarioCriacaoCodigo { get; set; }
        //public virtual Usuario Usuario_Criacao { get; set; }
        //public DateTime Data_Criacao { get; set; }
        //public int UsuarioEdicaoCodigo { get; set; }
        //public virtual Usuario Usuario_Edicao { get; set; }
        //public DateTime Data_Edicao { get; set; }

        public virtual List<MLL.AlunoNota> Notas { get; set; }
    }
}
