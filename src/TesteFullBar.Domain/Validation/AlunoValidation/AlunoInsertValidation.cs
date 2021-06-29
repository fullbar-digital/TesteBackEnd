using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Models;

namespace TesteFullBar.Domain.Validation.AlunoValidation
{
    public class AlunoInsertValidation : AbstractValidator<Aluno>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoInsertValidation(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("Nome do aluno não pode ser nulo");

            RuleFor(x => x.RA)
                .NotNull()
                .WithMessage("RA do aluno não pode ser nulo");

            RuleFor(x => x.Periodo)
                .NotNull()
                .WithMessage("Periodo do aluno não pode ser nulo");

            RuleFor(x => x.AlunoDisciplinas)
                .NotNull()
                .NotEmpty()
                .WithMessage("As disciplinas não podem ser nulo");

            //RuleFor(x => x.RA)
            //    .MustAsync(ValidationRA)
            //    .WithMessage("Aluno já cadastrado na base de dados");

        }

        private async Task<bool> ValidationRA(Aluno aluno, CancellationToken cancellationToken)
        {
            var alunoRepository = await _alunoRepository.GetByRaAsync(aluno.RA);

            return aluno.RA != alunoRepository?.RA;
        }
    }
}
