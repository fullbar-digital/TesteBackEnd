using MediatR;

namespace Teste.Application.Cursos.Remocao
{
    public class RemoverCursoCommand : IRequest<RemoverCursoResponse>
    {
        public string Id { get; set; } = default!;
    }
}
