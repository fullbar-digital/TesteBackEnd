using MediatR;

namespace Teste.Application.Alunos.Alteracao
{
    public class AlterarAlunoCommand : IRequest<AlterarAlunoResponse>
    {
        public string Id { get; set; } = default!;
        public string Nome { get; set; } = default!;
        public string RegistroAcademico { get; set; } = default!;
        public int Periodo { get; set; } = default!;
        public string CursoId { get; set; } = default!;
        public string Foto { get; set; } = default!;
    }
}
