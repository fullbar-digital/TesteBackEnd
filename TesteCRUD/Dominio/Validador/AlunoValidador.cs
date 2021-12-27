using Dominio.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Validador
{
    public class AlunoValidador : AbstractValidator<Aluno>
    {
        public AlunoValidador()
        {
            RuleFor(x => x)
               .NotEmpty()
                   .WithMessage("A entidade não pode ser vazia.")

               .NotNull()
               .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome do Aluno está vazio");

            RuleFor(x => x.RA)
                .NotNull()
                .WithMessage("O RA do Aluno está vazio");

            RuleFor(x => x.Periodo)
                .NotNull()
                .WithMessage("O Periodo do Aluno está vazio");

            RuleFor(x => x.CursoCodigo)
                .NotNull()
                .WithMessage("O Curso do Aluno está vazio");

            RuleFor(x => x.DataCriacao)
                .NotNull()
                .WithMessage("A Data de criação do Aluno está vazio");
        }
    }
}
