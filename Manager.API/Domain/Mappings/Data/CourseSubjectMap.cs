using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Mappings.Data
{
    class CourseSubjectMap : AbstractValidator<CourseSubject>
    {
        public CourseSubjectMap()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode está vazia");

            RuleFor(x => x.SubjectId)
                .NotNull()
                .WithMessage("Codigo da disciplina não pode está vazio");

            RuleFor(x => x.CourseId)
                .NotNull()
                .WithMessage("Codigo do curso não pode está vazio");
        }
    }
}
