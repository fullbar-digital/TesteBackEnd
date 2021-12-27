using Domain.Entities;
using Dominio.Validador;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class AlunoDisciplina : Base
    {
        public virtual int AlunoCodigo { get; set; }
        public Aluno Aluno { get; set; }
        public virtual int DisciplinaCodigo { get; set; }
        public Disciplina Disciplina { get; set; }
        public decimal Nota { get; set; }
        public string Status { get; set; }
        public DateTime? DataCriacao { get; set; }

        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoCodigo, Aluno aluno, int disciplinaCodigo, Disciplina disciplina, decimal nota, string status, DateTime? dataCriacao)
        {
            AlunoCodigo = alunoCodigo;
            Aluno = aluno;
            DisciplinaCodigo = disciplinaCodigo;
            Disciplina = disciplina;
            Nota = nota;
            Status = status;
            DataCriacao = dataCriacao;
        }

        public void alterarNota(decimal nota, string status, DateTime? dataCriacao, int codigo)
        {
            Codigo = codigo;
            Nota = nota;
            Status = status;
            DataCriacao = dataCriacao;
        }
        public override bool Validate()
        {
            var validador = new AlunoDisciplinaValidador();
            var validation = validador.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
