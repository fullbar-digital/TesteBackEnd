using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class AlunoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Ra { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }

        public List<RelacaoAlunoDisciplina> relacaoAlunoDisciplinas { get; set; }
    }
}