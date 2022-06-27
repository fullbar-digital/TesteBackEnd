using MediatR;

namespace Teste.Application.Alunos.Remocao
{
    public class RemoverAlunoCommand : IRequest<RemoverAlunoResponse>
    {
        public string Id { get; set; } = default!;
    }
}
