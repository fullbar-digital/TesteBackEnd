using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings.Data
{
    class CourseMap : AbstractValidator<Course>
    {
        public CourseMap()
        {
            RuleFor(x => x)
                .NotEmpty()
                    .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome da disciplina está vazio");

        }
    }
}
