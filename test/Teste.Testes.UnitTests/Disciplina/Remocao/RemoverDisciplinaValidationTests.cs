using Teste.Application.Disciplinas.Remocao;

namespace Teste.UnitTests.Disciplina.Remocao
{
    public class RemoverDisciplinaValidationTests
    {
        private RemoverDisciplinaValidation? _validation;

        public RemoverDisciplinaValidation Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new RemoverDisciplinaValidation();
                }

                return _validation;
            }
        }

        [Fact]
        public void Teste_Validacao_Disciplina_Id_Invalido()
        {
            var removerDisciplinaCommand = new RemoverDisciplinaCommand()
            {
                Id = string.Empty
            };            

            var erros = Validation.Validate(removerDisciplinaCommand);

            Assert.Contains("Id da disciplina inválido!", erros.Errors.Select(x => x.ErrorMessage));
        }        
    }
}
