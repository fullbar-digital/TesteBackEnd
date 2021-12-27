using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.DTO
{
    public class CursoDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<int> CodigoDisciplinas { get; set; }
        public List<CursoDisciplinaDTO> CursoDisciplinas { get; set; }
        public CursoDTO(){}

        public CursoDTO(int codigo, string nome, List<int> codigoDisciplinas, List<CursoDisciplinaDTO> cursoDisciplinas)
        {
            Codigo = codigo;
            Nome = nome;
            CodigoDisciplinas = codigoDisciplinas;
            CursoDisciplinas = cursoDisciplinas;
        }
    }
}
