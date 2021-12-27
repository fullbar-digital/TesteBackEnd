using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.DTO
{
    public class DisciplinaDTO
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int MinAprovacao { get; set; }

        public DisciplinaDTO(){}

        public DisciplinaDTO(int codigo, string nome, int minAprovacao)
        {
            Codigo = codigo;
            Nome = nome;
            MinAprovacao = minAprovacao;
        }
    }
}
