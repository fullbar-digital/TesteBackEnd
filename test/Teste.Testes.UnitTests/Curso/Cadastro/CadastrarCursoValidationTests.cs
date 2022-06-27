using Teste.Application.Cursos.Cadastro;
using Testes.UnitTests.Common.Fakers.Curso;

namespace Teste.UnitTests.Curso.Cadastro
{
    public class CadastrarCursoValidationTests
    {
        private CadastrarCursoValidation? _validation;

        public CadastrarCursoValidation Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new CadastrarCursoValidation();
                }

                return _validation;
            }
        }

        [Fact]
        public void Teste_Validacao_Curso_Nome_Vazio()
        {
            var cadastrarCursoCommand = new CadastrarCursoCommandFaker().Generate();
            cadastrarCursoCommand.Nome = string.Empty;

            var erros = Validation.Validate(cadastrarCursoCommand);

            Assert.Contains("Informe o nome do curso!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Curso_Nome_Maior_200_Caracters()
        {
            var cadastrarCursoCommand = new CadastrarCursoCommandFaker().Generate();
            cadastrarCursoCommand.Nome = "UM NOME QUALQUER COM MAIS DE 200 CARACTERES, PRECISA TER MAIS DE 200 CARACTERES PARA PASSAR NA VALIDAÇÃO POR ISSO ESTAMOS ESCREVENDO MUITAS COISAS ALEATORIAS PARA QUE DE MAIS DE 200 CARACTERES NO NOME LALALA";

            var erros = Validation.Validate(cadastrarCursoCommand);

            Assert.Contains("O nome do curso precisa ter até 200 caracteres!", erros.Errors.Select(x => x.ErrorMessage));
        }
    }
}
