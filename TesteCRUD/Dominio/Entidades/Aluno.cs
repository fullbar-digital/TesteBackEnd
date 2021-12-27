using Domain.Entities;
using Dominio.Validador;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Aluno : Base
    {
        public string Nome { get; set; }
        public string RA { get; set; }
        public string Periodo { get; set; }
        public string Foto { get; set; }
        public DateTime? DataCriacao { get; set; }
        public virtual int CursoCodigo { get; set; }
        public Curso Curso { get; set; }
        public virtual ICollection<AlunoDisciplina> AlunoDisciplina { get; set; }
        public Aluno(){}
        public Aluno(string nome, string rA, string periodo, string foto, int codigoCurso, Curso curso, DateTime? dataCriacao)
        {
            Nome = nome;
            RA = rA;
            Periodo = periodo;
            Foto = foto;
            CursoCodigo = codigoCurso;
            Curso = curso;
            DataCriacao = dataCriacao;
            _errors = new List<string>();

            Validate();
        }

        public void AlterarAluno(string nome, string rA, string periodo, string foto, int codigoCurso)
        {
            Nome = nome;
            RA = rA;
            Periodo = periodo;
            Foto = foto;
            CursoCodigo = codigoCurso;
        }

        public override bool Validate()
        {
            var validator = new AlunoValidador();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                _errors = new List<string>();
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
