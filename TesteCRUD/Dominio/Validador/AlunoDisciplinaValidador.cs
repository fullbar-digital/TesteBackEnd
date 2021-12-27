using Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validador
{
    public class AlunoDisciplinaValidador : AbstractValidator<AlunoDisciplina>
    {
        public AlunoDisciplinaValidador()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode está vazia");

            RuleFor(x => x.DisciplinaCodigo)
                .NotNull()
                .WithMessage("Codigo da disciplina não pode está vazio");

            RuleFor(x => x.AlunoCodigo)
                .NotNull()
                .WithMessage("Codigo do aluno não pode está vazio");

            RuleFor(x => x.Nota)
                .NotNull()
                .WithMessage("Codigo da disciplina não pode está vazio");
        }
    }
}
