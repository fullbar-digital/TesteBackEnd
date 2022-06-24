
using Teste.Domain.Alunos.Entities;
using Teste.Domain.Common.Entities;
using Teste.Domain.Disciplinas.Entities;

namespace Teste.Domain.Cursos.Entitites
{
    public class Curso : BaseEntity
    {
        public string Nome { get; set; } = default!;

        public List<Disciplina> Disciplinas { get; set; } = new();
        public List<Aluno> Alunos { get; set; } = new();
    }
}
