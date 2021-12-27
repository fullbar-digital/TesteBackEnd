using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.DTO
{
    public class GetAlunoDisciplinaDTO
    {
        public string NomeDisciplina { get; set; }
        public int MinAprovacao { get; set; }
        public decimal Nota { get; set; }
        public string Status { get; set; }

        public GetAlunoDisciplinaDTO() { }
        public GetAlunoDisciplinaDTO(decimal nota, string status)
        {
            Nota = nota;
            Status = status;
        }
        public GetAlunoDisciplinaDTO(string nome, int minAprovacao, decimal nota, string status)
        {
            NomeDisciplina = nome;
            MinAprovacao = minAprovacao;
            Nota = nota;
            Status = status;
        }
    }
}
