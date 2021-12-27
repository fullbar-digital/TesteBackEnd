using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.DTO
{
    public class AlunoDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string RA { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }
        public int CursoCodigo { get; set; }
        public List<AlunoDisciplinaDTO> AlunoDisciplinaDTO { get; set; }

        public AlunoDTO(){}

        public AlunoDTO(int codigo, string nome, string rA, string periodo, string foto, int codigoCurso)
        {
            Codigo = codigo;
            Nome = nome;
            RA = rA;
            Periodo = periodo;
            Foto = foto;
            CursoCodigo = codigoCurso;
        }
    }
}
