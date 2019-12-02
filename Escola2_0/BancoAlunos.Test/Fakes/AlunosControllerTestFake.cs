using BancoAlunos.Models;
using System.Collections.Generic;
using System.Linq;

namespace BancoAlunos.Test.Fake
{
    public class AlunosControllerTestFake
    {
        #region BancoDadosFake
        List<Alunos> output = new List<Alunos>()
            {
                new Alunos()
                {
                    Id = 1,
                    Nome = "Lucas",
                    RA = 123132,
                    Curso = "CNC Computacao",
                    Periodo = "Noturno",
                    Nota = 10
                },
                new Alunos()
                {
                    Id = 2,
                    Nome = "Maria",
                    RA = 233132,
                    Curso = "CNC Computacao",
                    Periodo = "Noturno",
                    Nota = 5
                },
                new Alunos()
                {
                    Id = 3,
                    Nome = "Joao",
                    RA = 223132,
                    Curso = "CNC Computacao",
                    Periodo = "Noturno",
                    Nota = 8
                },
                new Alunos()
                {
                    Id = 4,
                    Nome = "Fernando",
                    RA = 233332,
                    Curso = "CNC Computacao",
                    Periodo = "Matutino",
                    Nota = 2
                }
            };
        #endregion

        //Metodos

        #region MetodosAcessoDbFake
        public List<Alunos> GetAlunosFake()
        {
            return output;
        }

        public Alunos GetAlunosByIdFake(int id)
        {
            return this.output.FirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
