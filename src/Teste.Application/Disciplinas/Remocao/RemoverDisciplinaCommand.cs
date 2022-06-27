using MediatR;

namespace Teste.Application.Disciplinas.Remocao
{
    public class RemoverDisciplinaCommand : IRequest<RemoverDisciplinaResponse>
    {
        public string Id { get; set; } = default!;
    }
}
