using MediatR;

namespace Teste.Application.Disciplinas.Alteracao
{
    public class AlterarDisciplinaCommand : IRequest<AlterarDisciplinaResponse>
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public decimal NotaMinimaAprovacao { get; set; }
        public string CursoId { get; set; } = default!;
    }
}
