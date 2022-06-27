using Teste.Application.Cursos.Remocao;

namespace Teste.UnitTests.Curso.Remocao
{
    public class RemoverCursoValidationTests
    {
        private RemoverCursoValidation? _validation;

        public RemoverCursoValidation Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new RemoverCursoValidation();
                }

                return _validation;
            }
        }

        [Fact]
        public void Teste_Validacao_Curso_Id_Invalido()
        {
            var removerCursoCommand = new RemoverCursoCommand()
            {
                Id = string.Empty
            };            

            var erros = Validation.Validate(removerCursoCommand);

            Assert.Contains("Id do curso inválido!", erros.Errors.Select(x => x.ErrorMessage));
        }        
    }
}
