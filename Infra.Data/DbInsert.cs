using Domain.Entities;
using Infra.Data.Context;
using System;
using System.Linq;

namespace Infra.Data
{
    public static class DbInsert
    {
        public static void Initialize(BaseContext context)
        {
            context.Database.EnsureCreated();
            if (context.Alunos.Any() && context.Disciplinas.Any() && context.Cursos.Any())
                return;

            var cursos = new Curso[]
            {
                new Curso{
                    Nome = "Engenharia de Software",
                    CursoInicio = DateTime.UtcNow,
                    CursoFim = DateTime.UtcNow
                },
                new Curso{
                    Nome = "Medicina",
                    CursoInicio = DateTime.UtcNow,
                    CursoFim = DateTime.UtcNow
                },
                new Curso{
                    Nome = "Direito",
                    CursoInicio = DateTime.UtcNow,
                    CursoFim = DateTime.UtcNow
                }
            };

            foreach (var curso in cursos)
                context.Cursos.Add(curso);

            context.SaveChanges();

            var disciplinas = new Disciplina[]
            {
                new Disciplina{
                    Nome = "Clínica Cirúrgica",
                    NotaMinima = 7.0,
                    CursoId = cursos[1].Id,
                    DisciplinaInicio = DateTime.Now,
                    DisciplinaFim = DateTime.Now
                },
                new Disciplina{
                    Nome = "Desenvolvimento Web",
                    NotaMinima = 7.0,
                    CursoId = cursos[0].Id,
                    DisciplinaInicio = DateTime.Now,
                    DisciplinaFim = DateTime.Now
                },
                  new Disciplina{
                    Nome = "Desenvolvimento Mobile",
                    NotaMinima = 7.0,
                    CursoId = cursos[0].Id,
                    DisciplinaInicio = DateTime.Now,
                    DisciplinaFim = DateTime.Now
                },
                new Disciplina{
                    Nome = "Leis Trabalhistas",
                    NotaMinima = 6.5,
                    CursoId = cursos[2].Id,
                    DisciplinaInicio = DateTime.Now,
                    DisciplinaFim = DateTime.Now
                }
            };

            foreach (var disciplina in disciplinas)
                context.Disciplinas.Add(disciplina);

            context.SaveChanges();

            var alunos = new Aluno[]
            {
                new Aluno{
                    Nome = "Amanda",
                    Ra = "20205514",
                    Periodo = "Manhã",
                    Foto = "https://cdn.pixabay.com/photo/2017/06/08/16/30/marilyn-monroe-2384020_1280.jpg",
                    CursoId = cursos[2].Id
                },
                new Aluno{
                    Nome = "Joana",
                    Ra = "20203464",
                    Periodo = "Tarde",
                    Foto = "https://cdn.pixabay.com/photo/2018/10/14/18/09/painting-3747058_1280.jpg",
                    CursoId = cursos[0].Id
                },
                new Aluno{
                    Nome = "Bruno",
                    Ra = "202054976",
                    Periodo = "Noite",
                    Foto = "https://cdn.pixabay.com/photo/2019/02/22/12/01/sit-4013410_960_720.jpg",
                    CursoId = cursos[0].Id
                },
                  new Aluno{
                    Nome = "Thiago",
                    Ra = "202034614",
                    Periodo = "Noite",
                    Foto = "https://cdn.pixabay.com/photo/2014/10/31/17/41/dancing-dave-minion-510835_960_720.jpg",
                    CursoId = cursos[1].Id
                },
            };
            foreach (var aluno in alunos)
            {
                context.Alunos.Add(aluno);
            }
            context.SaveChanges();

            var alunoNotas = new RelacaoAlunoDisciplina[]
            {
                new RelacaoAlunoDisciplina{
                    Nota = 8.5,
                    RelacaoAlunoId = alunos[0].Id,
                    RelacaoDisciplinaId = disciplinas[3].Id,
                    CreateAt = DateTime.UtcNow
                },
                  new RelacaoAlunoDisciplina{
                    Nota = 6.5,
                    RelacaoAlunoId = alunos[1].Id,
                    RelacaoDisciplinaId = disciplinas[1].Id,
                    CreateAt = DateTime.UtcNow
                },
                    new RelacaoAlunoDisciplina{
                    Nota = 4.5,
                    RelacaoAlunoId = alunos[1].Id,
                    RelacaoDisciplinaId = disciplinas[2].Id,
                    CreateAt = DateTime.UtcNow
                },
                    new RelacaoAlunoDisciplina{
                    Nota = 3.5,
                    RelacaoAlunoId = alunos[2].Id,
                    RelacaoDisciplinaId = disciplinas[1].Id,
                    CreateAt = DateTime.UtcNow
                },
                    new RelacaoAlunoDisciplina{
                    Nota = 4.5,
                    RelacaoAlunoId = alunos[2].Id,
                    RelacaoDisciplinaId = disciplinas[2].Id,
                    CreateAt = DateTime.UtcNow
                },
                    new RelacaoAlunoDisciplina{
                    Nota = 9.5,
                    RelacaoAlunoId = alunos[3].Id,
                    RelacaoDisciplinaId = disciplinas[0].Id,
                    CreateAt = DateTime.UtcNow
                },
            };
            foreach (var alunoNota in alunoNotas)
                context.RelacaoAlunoDisciplinas.Add(alunoNota);

            context.SaveChanges();
        }
    }
}