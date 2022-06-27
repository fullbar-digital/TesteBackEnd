using MediatR;

namespace Teste.Application.Cursos.Alteracao
{
    public class AlterarCursoCommand : IRequest<AlterarCursoResponse>
    {
        public string CursoId { get; set; } = default!;
        public string Nome { get; set; } = default!;
    }
}
