using MediatR;

namespace Teste.Application.Alunos.Cadastro
{
    public class CadastrarAlunoCommand : IRequest<CadastrarAlunoResponse>
    {
        public string Nome { get; set; } = default!;
        public string RegistroAcademico { get; set; } = default!;
        public int Periodo { get; set; } = default!;
        public string CursoId { get; set; } = default!;
        public string Foto { get; set; } = default!;

    }
}
