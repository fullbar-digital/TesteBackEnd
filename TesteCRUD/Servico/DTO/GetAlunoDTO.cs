using Servico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servico.DTO
{
    public class GetAlunoDTO
    {
        public string Nome { get; set; }
        public string RA { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }
        public CursoDTO Curso { get; set; }
        public IList<GetAlunoDisciplinaDTO> Disciplinas { get; set; }

        public GetAlunoDTO(){}

        public GetAlunoDTO(string nome, string rA, string periodo, string foto)
        {
            Nome = nome;
            RA = rA;
            Periodo = periodo;
            Foto = foto;
        }

        public GetAlunoDTO(string nome, string rA, string periodo, string foto, DateTime? dataCriacao, CursoDTO curso, IList<GetAlunoDisciplinaDTO> disciplinas)
        {
            Nome = nome;
            RA = rA;
            Periodo = periodo;
            Foto = foto;
            Curso = curso;
            Disciplinas = disciplinas;
        }
    }
}
