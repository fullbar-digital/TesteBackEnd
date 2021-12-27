using Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validador
{
    public class DisciplinaValidador : AbstractValidator<Disciplina>
    {
        public DisciplinaValidador()
        {
            RuleFor(x => x)
                .NotEmpty()
                    .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome da disciplina está vazio");

            RuleFor(x => x.MinAprovacao)
                .NotNull()
                .WithMessage("O valor minimo para aprovar na disciplina está vázio");
        }
    }
}
