using MediatR;

namespace Teste.Application.Disciplinas.Remocao
{
    public class RemoverDisciplinaCommand : IRequest<RemoverDisciplinaResponse>
    {
        public string DisciplinaId { get; set; } = default!;
    }
}
