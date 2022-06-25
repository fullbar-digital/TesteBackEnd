using Teste.Application.Disciplinas.Dtos;

namespace Teste.Application.Disciplinas.ObterTodas
{
    public class ObterTodasDisciplinasResponse
    {
        public ObterTodasDisciplinasResponse(List<DisciplinaDto> disciplinas)
        {
            Disciplinas = disciplinas;
        }

        public List<DisciplinaDto> Disciplinas { get; set; } = new();
    }
}
