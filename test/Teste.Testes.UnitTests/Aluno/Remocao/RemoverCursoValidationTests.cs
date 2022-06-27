using Teste.Application.Alunos.Remocao;

namespace Teste.UnitTests.Aluno.Remocao
{
    public class RemoverAlunoValidationTests
    {
        private RemoverAlunoValidation? _validation;

        public RemoverAlunoValidation Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new RemoverAlunoValidation();
                }

                return _validation;
            }
        }

        [Fact]
        public void Teste_Validacao_Aluno_Id_Invalido()
        {
            var removerAlunoCommand = new RemoverAlunoCommand()
            {
                Id = string.Empty
            };            

            var erros = Validation.Validate(removerAlunoCommand);

            Assert.Contains("Id do aluno inválido!", erros.Errors.Select(x => x.ErrorMessage));
        }        
    }
}
