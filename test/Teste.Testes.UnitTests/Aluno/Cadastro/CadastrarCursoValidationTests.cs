using Teste.Application.Alunos.Cadastro;
using Testes.UnitTests.Common.Fakers.Aluno;

namespace Teste.UnitTests.Aluno.Cadastro
{
    public class CadastrarAlunoValidationTests
    {
        private CadastrarAlunoValidation? _validation;

        public CadastrarAlunoValidation Validation
        {
            get
            {
                if (_validation == null)
                {
                    _validation = new CadastrarAlunoValidation();
                }

                return _validation;
            }
        }

        [Fact]
        public void Teste_Validacao_Aluno_Nome_Vazio()
        {
            var cadastrarAlunoCommand = new CadastrarAlunoCommandFaker().Generate();
            cadastrarAlunoCommand.Nome = string.Empty;

            var erros = Validation.Validate(cadastrarAlunoCommand);

            Assert.Contains("Informe o nome do aluno!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Aluno_Nome_Maior_200_Caracters()
        {
            var cadastrarAlunoCommand = new CadastrarAlunoCommandFaker().Generate();
            cadastrarAlunoCommand.Nome = "UM NOME QUALQUER COM MAIS DE 200 CARACTERES, PRECISA TER MAIS DE 200 CARACTERES PARA PASSAR NA VALIDAÇÃO POR ISSO ESTAMOS ESCREVENDO MUITAS COISAS ALEATORIAS PARA QUE DE MAIS DE 200 CARACTERES NO NOME LALALA";

            var erros = Validation.Validate(cadastrarAlunoCommand);

            Assert.Contains("O nome do aluno precisa ter até 200 caracteres!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Aluno_RA_Vazio()
        {
            var cadastrarAlunoCommand = new CadastrarAlunoCommandFaker().Generate();
            cadastrarAlunoCommand.RegistroAcademico = string.Empty;

            var erros = Validation.Validate(cadastrarAlunoCommand);

            Assert.Contains("Informe o registro acadêmico do aluno!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Aluno_RA_Maior_200_Caracters()
        {
            var cadastrarAlunoCommand = new CadastrarAlunoCommandFaker().Generate();
            cadastrarAlunoCommand.RegistroAcademico = "UM NOME QUALQUER COM MAIS DE 200 CARACTERES, PRECISA TER MAIS DE 200 CARACTERES PARA PASSAR NA VALIDAÇÃO POR ISSO ESTAMOS ESCREVENDO MUITAS COISAS ALEATORIAS PARA QUE DE MAIS DE 200 CARACTERES NO NOME LALALA";

            var erros = Validation.Validate(cadastrarAlunoCommand);

            Assert.Contains("O registro acadêmico do aluno precisa ter até 200 caracteres!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Aluno_Periodo_Deve_Ser_Maior_0()
        {
            var cadastrarDisciplinaCommand = new CadastrarAlunoCommandFaker().Generate();
            cadastrarDisciplinaCommand.Periodo = 0;

            var erros = Validation.Validate(cadastrarDisciplinaCommand);

            Assert.Contains("O período do aluno precisa ser maior que 0!", erros.Errors.Select(x => x.ErrorMessage));
        }

        [Fact]
        public void Teste_Validacao_Aluno_Id_Curso_Invalido()
        {
            var cadastrarAlunoCommand = new CadastrarAlunoCommandFaker().Generate();
            cadastrarAlunoCommand.CursoId = string.Empty;

            var erros = Validation.Validate(cadastrarAlunoCommand);

            Assert.Contains("Id do curso inválido!", erros.Errors.Select(x => x.ErrorMessage));
        }
    }
}
