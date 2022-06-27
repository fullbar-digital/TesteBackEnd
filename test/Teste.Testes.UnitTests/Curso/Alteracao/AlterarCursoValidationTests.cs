using Teste.Application.Cursos.Alteracao;
using Testes.UnitTests.Common.Fakers;
using Testes.UnitTests.Common.Fakers.Curso;

namespace Teste.UnitTests.Curso.Alteracao
{
    public class AlterarCursoValidationTests
    {
        private AlterarCursoValidation? _validation;

        public AlterarCursoValidation Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new AlterarCursoValidation();
                }

                return _validation;
            }
        }

        [Fact]
        public void Teste_Validacao_Curso_Id_Invalido()
        {
            var alterarCursoCommand = new AlterarCursoCommandFaker().Generate();
            alterarCursoCommand.CursoId = string.Empty;

            var erros = Validation.Validate(alterarCursoCommand);

            Assert.Contains("Id do curso inválido!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Curso_Nome_Vazio()
        {
            var alterarCursoCommand = new AlterarCursoCommandFaker().Generate();
            alterarCursoCommand.Nome = string.Empty;

            var erros = Validation.Validate(alterarCursoCommand);

            Assert.Contains("Informe o nome do curso!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Curso_Nome_Maior_200_Caracters()
        {
            var alterarCursoCommand = new AlterarCursoCommandFaker().Generate();
            alterarCursoCommand.Nome = "UM NOME QUALQUER COM MAIS DE 200 CARACTERES, PRECISA TER MAIS DE 200 CARACTERES PARA PASSAR NA VALIDAÇÃO POR ISSO ESTAMOS ESCREVENDO MUITAS COISAS ALEATORIAS PARA QUE DE MAIS DE 200 CARACTERES NO NOME LALALA";

            var erros = Validation.Validate(alterarCursoCommand);

            Assert.Contains("O nome do curso precisa ter até 200 caracteres!", erros.Errors.Select(x => x.ErrorMessage));
        }
    }
}
