using MediatR;

namespace Teste.Application.Alunos.Filtro
{
    public class FiltrarAlunoCommand : IRequest<FiltrarAlunoResponse>
    {
        public string? Nome { get; set; }
        public string? RegistroAcademico { get; set; }
        public string? Curso { get; set; }
        public string? Status { get; set; }

    }
}
