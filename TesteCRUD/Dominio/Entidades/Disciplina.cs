using Domain.Entities;
using Dominio.Validador;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Disciplina : Base
    {
        public string Nome { get; set; }
        public int MinAprovacao { get; set; }
        public DateTime? DataCriacao { get; set; }
        public ICollection<CursoDisciplina> CursoDisciplina { get; set; }
        public ICollection<AlunoDisciplina> AlunoDisciplina { get; set; }

        public Disciplina(){}

        public Disciplina(string nome, int minAprovacao, DateTime dataCriacao)
        {
            Nome = nome;
            MinAprovacao = minAprovacao;
            DataCriacao = dataCriacao;
            _errors = new List<string>();

            Validate();
        }

        public override bool Validate()
        {
            var validator = new DisciplinaValidador();
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

        public void AlterarEmpresa(string nome, int minAprovacao) 
        {
            Nome = nome;
            MinAprovacao = minAprovacao;
            Validate();
        }
    }
}
