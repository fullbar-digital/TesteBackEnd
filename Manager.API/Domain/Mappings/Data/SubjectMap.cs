using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings.Data
{
    class SubjectMap : AbstractValidator<Subject>
    {
        public SubjectMap()
        {
            RuleFor(x => x)
                .NotEmpty()
                    .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome da disciplina está vazio");

            RuleFor(x => x.ApproveMin)
                .NotNull()
                .WithMessage("O valor minimo para aprovar na disciplina está vázio")

                .GreaterThan(6)
                .WithMessage("O campo MinAprovacao precisa ter o valor minimo de 7");

        }
    }
}
