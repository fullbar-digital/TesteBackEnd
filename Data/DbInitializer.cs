using Data.Context;
using Domain;
using System.Linq;

namespace Data
{
    public static class DbInitializer
    {
        public static void Initialize(GestaoAcademicaContext context)
        {
            context.Database.EnsureCreated();
            if(context.Cursos.Any() && context.Disciplinas.Any() && context.Alunos.Any())
            {
                return;
            }

            var cursos = new Curso[]
            {
                new Curso{Nome = "Análise e Desenvolvimento de Sistemas"},
                new Curso{Nome = "Biologia"},
                new Curso{Nome = "Direito"}
            };
            foreach (var curso in cursos)
            {
                context.Cursos.Add(curso);
            }
            context.SaveChanges();

            var disciplinas = new Disciplina[]
            {
                
                new Disciplina{Nome = "Biologia Molecular", NotaMinimaAprovacao = 6.0, CursoId = 2},
                new Disciplina{Nome = "Estruturas de dados", NotaMinimaAprovacao = 6.0, CursoId = 1},
                new Disciplina{Nome = "Cálculo I", NotaMinimaAprovacao = 6.0, CursoId = 1},
                new Disciplina{Nome = "Química I", NotaMinimaAprovacao= 6.0, CursoId = 2},
                new Disciplina{Nome = "Direito Penal", NotaMinimaAprovacao = 6.0, CursoId = 3},
                new Disciplina{Nome = "Direito Internacional", NotaMinimaAprovacao = 6.0, CursoId = 3}
            };
            foreach (var disciplina in disciplinas)
            {
                context.Disciplinas.Add(disciplina);
            }
            context.SaveChanges();

            var alunos = new Aluno[]
            {
                new Aluno{Nome = "Pedro", Ra = "2020012599", Periodo = 1, CursoId = 3, Foto = "https://cdn.pixabay.com/photo/2020/07/03/16/42/amsterdam-5367020_960_720.jpg"},
                new Aluno{Nome = "Maria", Ra = "2019014910", Periodo = 1, CursoId = 2, Foto = "https://cdn.pixabay.com/photo/2020/07/03/06/12/people-5365324_960_720.jpg"},
                new Aluno{Nome = "João", Ra = "2020012930", Periodo = 1, CursoId = 1, Foto = "https://cdn.pixabay.com/photo/2016/04/25/18/07/halcyon-1352522_960_720.jpg"}
            };
            foreach (var aluno in alunos)
            {
                context.Alunos.Add(aluno);
            }
            context.SaveChanges();

            var alunosDisciplinas = new AlunoDisciplina[]
            {
                new AlunoDisciplina{AlunoId = 1, DisciplinaId = 1, Nota = 5.5},
                new AlunoDisciplina{AlunoId = 1, DisciplinaId = 2, Nota = 7.3},
                new AlunoDisciplina{AlunoId = 2, DisciplinaId = 3, Nota = 8.0},
                new AlunoDisciplina{AlunoId = 2, DisciplinaId = 4, Nota = 9.2},
                new AlunoDisciplina{AlunoId = 3, DisciplinaId = 5, Nota = 4.8},
                new AlunoDisciplina{AlunoId = 3, DisciplinaId = 6, Nota = 6.0}
            };
            foreach (var alunoDisciplina in alunosDisciplinas)
            {
                context.AlunosDisciplinas.Add(alunoDisciplina);
            }
            context.SaveChanges();
        }
    }
}
