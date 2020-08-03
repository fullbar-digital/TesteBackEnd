using Business;
using Domain;

namespace DTO
{
    public static class Conversao
    {
        public static AlunoDTO AlunoToAlunoDTO(Aluno aluno)
        {
            if (aluno == null) 
                return new AlunoDTO();

            AlunoDTO alunoDto = new AlunoDTO();
            alunoDto.AlunoId = aluno.AlunoId;
            alunoDto.Nome = aluno.Nome;
            alunoDto.Ra = aluno.Ra;
            alunoDto.Curso = aluno.Curso.Nome;
            alunoDto.Periodo = aluno.Periodo;
            alunoDto.Foto = aluno.Foto;
            foreach (var disciplina in aluno.Curso.Disciplinas)
            {
                DisciplinaDTO disciplinaDTO = new DisciplinaDTO();
                disciplinaDTO.Nome = disciplina.Nome;
                var nota = aluno.AlunosDisciplinas.Find(x => x.DisciplinaId == disciplina.DisciplinaId).Nota;
                disciplinaDTO.Nota = nota;
                disciplinaDTO.Status = VerificadorAprovacao.IsAprovado(nota, disciplina.NotaMinimaAprovacao);
                alunoDto.Disciplinas.Add(disciplinaDTO);
            }
            return alunoDto;
        }
    }
}
