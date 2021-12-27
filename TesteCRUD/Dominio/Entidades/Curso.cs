using Domain.Entities;
using Dominio.Validador;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Curso : Base
    {
        public string Nome { get; set; }
        public DateTime? DataCriacao { get; set; }
        public virtual ICollection<CursoDisciplina> CursoDisciplina { get; set; }
        public virtual ICollection<Aluno> Alunos{ get; set; }

        public Curso(){}

        public Curso(string nome, DateTime dataCriacao)
        {
            Nome = nome;
            DataCriacao = dataCriacao;
            _errors = new List<string>();

            Validate();
        }

        public void AlterarCurso(string nome)
        {
            Nome = nome;
        }

        public override bool Validate()
        {
            var validator = new CursoValidador();
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
