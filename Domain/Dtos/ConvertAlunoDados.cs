using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class ConvertAlunoDados
    {
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }
        public string Ra { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }

        public string CursoNome { get; set; }
        public List<DisciplinaDto> Disciplinas { get; set; }

        public ConvertAlunoDados(Aluno aluno)
        {
            this.AlunoId = aluno.Id;
            this.Nome = aluno.Nome;
            this.Ra = aluno.Ra;
            this.Periodo = aluno.Periodo;
            this.Foto = aluno.Foto;
            this.CursoNome = aluno.Curso.Nome;

            var listDto = new List<DisciplinaDto>();
            foreach (var disciplina in aluno.Curso.Disciplinas)
            {
                double nota = 0.0;
                foreach (var relacao in aluno.RelacaoAlunoDisciplinas)
                {
                    if (relacao.RelacaoDisciplinaId == disciplina.Id)
                    {
                        nota = relacao.Nota;
                    }
                }

                var status = (nota < disciplina.NotaMinima ? "Reprovado" : "Aprovado");
                DisciplinaDto disciplinaDto = new DisciplinaDto() { Nome = disciplina.Nome, Nota = nota, Status = status };
                listDto.Add(disciplinaDto);
            }
            this.Disciplinas = listDto;
        }
    }
}