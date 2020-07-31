using System;
using CRUD.Model;

namespace CRUD.ViewModel
{
    public class AlunoViewModel
    {
        public AlunoViewModel() { }

        public AlunoViewModel(Aluno aluno)
        {
            this.id = aluno.Id.ToString();
            this.nome = aluno.Nome;
            this.registroAcademico = aluno.RA;
            this.periodo = aluno.Periodo.ToString();
            this.curso = aluno.Curso;
            this.nota = aluno.Nota.ToString();
        }

        public string id { get; set; }

        public string nome { get; set; }

        public string registroAcademico { get; set; }

        public string periodo { get; set; }

        public string curso { get; set; }

        public string nota { get; set; }

        public string status
        {
            get
            {
                return nota != null && nota != "" && int.Parse(nota) > 7 ? "aprovado" : "reprovado";
            }
        }
    }
}
