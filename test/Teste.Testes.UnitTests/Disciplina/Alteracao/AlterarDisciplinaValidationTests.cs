using Teste.Application.Disciplinas.Alteracao;
using Testes.UnitTests.Common.Fakers;
using Testes.UnitTests.Common.Fakers.Disciplina;

namespace Teste.UnitTests.Disciplina.Alteracao
{
    public class AlterarDisciplinaValidationTests
    {
        private AlterarDisciplinaValidation? _validation;

        public AlterarDisciplinaValidation Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new AlterarDisciplinaValidation();
                }

                return _validation;
            }
        }

        [Fact]
        public void Teste_Validacao_Disciplina_Id_Invalido()
        {
            var alterarDisciplinaCommand = new AlterarDisciplinaCommandFaker().Generate();
            alterarDisciplinaCommand.Id = string.Empty;

            var erros = Validation.Validate(alterarDisciplinaCommand);

            Assert.Contains("Id da disciplina inválido!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Disciplina_Nome_Vazio()
        {
            var cadastrarDisciplinaCommand = new AlterarDisciplinaCommandFaker().Generate();
            cadastrarDisciplinaCommand.Nome = string.Empty;

            var erros = Validation.Validate(cadastrarDisciplinaCommand);

            Assert.Contains("Informe o nome da disciplina!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Disciplina_Nome_Maior_200_Caracters()
        {
            var cadastrarDisciplinaCommand = new AlterarDisciplinaCommandFaker().Generate();
            cadastrarDisciplinaCommand.Nome = "UM NOME QUALQUER COM MAIS DE 200 CARACTERES, PRECISA TER MAIS DE 200 CARACTERES PARA PASSAR NA VALIDAÇÃO POR ISSO ESTAMOS ESCREVENDO MUITAS COISAS ALEATORIAS PARA QUE DE MAIS DE 200 CARACTERES NO NOME LALALA";

            var erros = Validation.Validate(cadastrarDisciplinaCommand);

            Assert.Contains("O nome da disciplina precisa ter até 200 caracteres!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Disciplina_NotaMinima_Deve_Ser_Maior_0()
        {
            var cadastrarDisciplinaCommand = new AlterarDisciplinaCommandFaker().Generate();
            cadastrarDisciplinaCommand.NotaMinimaAprovacao = 0.0m;

            var erros = Validation.Validate(cadastrarDisciplinaCommand);

            Assert.Contains("A nota minima de aprovação precisa ser maior que 0!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Disciplina_Id_Curso_Invalido()
        {
            var cadastrarDisciplinaCommand = new AlterarDisciplinaCommandFaker().Generate();
            cadastrarDisciplinaCommand.CursoId = string.Empty;

            var erros = Validation.Validate(cadastrarDisciplinaCommand);

            Assert.Contains("Id do curso inválido!", erros.Errors.Select(x => x.ErrorMessage));
        }
    }
}
