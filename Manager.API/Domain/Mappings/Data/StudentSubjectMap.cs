using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings.Data
{
    class StudentSubjectMap : AbstractValidator<StudentSubject>
    {
        public StudentSubjectMap()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode está vazia");

            RuleFor(x => x.SubjectId)
                .NotNull()
                .WithMessage("Codigo da disciplina não pode está vazio");

            RuleFor(x => x.StudentId)
                .NotNull()
                .WithMessage("Codigo do aluno não pode está vazio");
        }
    }
}
