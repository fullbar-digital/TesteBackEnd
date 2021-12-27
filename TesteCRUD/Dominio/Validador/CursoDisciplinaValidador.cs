using Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validador
{
    public class CursoDisciplinaValidador : AbstractValidator<CursoDisciplina>
    {
        public CursoDisciplinaValidador()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode está vazia");

            RuleFor(x => x.DisciplinaCodigo)
                .NotNull()
                .WithMessage("Codigo da disciplina não pode está vazio");

            RuleFor(x => x.CursoCodigo)
                .NotNull()
                .WithMessage("Codigo do curso não pode está vazio");
        }
    }
}
