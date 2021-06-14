using System.Collections.Generic;

namespace Fullbar.Teste.Domain.Entities
{
    public class Curso : Entity
    {
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
        public IEnumerable<Aluno> Alunos { get; set; }
    }
}