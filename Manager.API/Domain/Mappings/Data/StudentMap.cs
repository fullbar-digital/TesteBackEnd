using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings.Data
{
    class StudentMap : AbstractValidator<Student>
    {
        public StudentMap()
        {
            RuleFor(x => x)
               .NotEmpty()
                   .WithMessage("A entidade não pode ser vazia.")

               .NotNull()
               .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome do Aluno está vazio");

            RuleFor(x => x.RA)
                .NotNull()
                .WithMessage("O RA do Aluno está vazio");

            RuleFor(x => x.Turn)
                .NotNull()
                .WithMessage("O Periodo do Aluno está vazio");

            RuleFor(x => x.CodeCourse)
                .NotNull()
                .WithMessage("O Curso do Aluno está vazio");
        }
    }
}
