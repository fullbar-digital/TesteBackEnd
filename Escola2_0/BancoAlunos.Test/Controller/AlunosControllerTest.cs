using Autofac.Extras.Moq;
using BancoAlunos.Controllers;
using BancoAlunos.Interfaces;
using BancoAlunos.Models;
using BancoAlunos.Test.Fake;
using Moq;
using Xunit;

namespace BancoAlunos.Test.Controller
{
    public class AlunosControllerTest
    {
        AlunosControllerTestFake _fakes = new AlunosControllerTestFake();

        #region GetAllAlunosTest_FirstTeste
        [Fact]
        public void GetAllAlunos_ValidarRetorno()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //O Mock está Conhecendo a Nossa Classe que Tem os Métodos Ligados a Base e Criando
                //uma "Copia" de Teste Para Os Dados Não Serem Processados na DB Principal!
                //Em Returns é Passado o Método Fake Criado que É o que Deve Retornar!
                mock.Mock<IAlunosRepository>()
                    .Setup(x => x.GetAllData())
                    .Returns(_fakes.GetAlunosFake());

                //O Mock Cria os Dados Que Sao Passados Para o Controller e Se Encarrega de Testar!
                var ctlr = mock.Create<AlunosController>();
                //Valor esperado do Método Fake!
                var expected = _fakes.GetAlunosFake();
                //Framework Retorna o Mesmo Count do Nosso Método Fake para usar no Assert!
                var actual = ctlr.GetAllAlunos();

                //Assert Caso o 'actual' falhe!
                Assert.True(actual != null);
                //Assert que consulta se os Counts do Mock e do método Fake são iguais!
                Assert.Equal(expected.Count, actual.Count);

            }
        }
        #endregion

        #region GetAlunosById_SecondTeste
        [Fact]
        public void GetAllAlunosById_ValidarRetorno()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IAlunosRepository>()
                    .Setup(x => x.GetAlunosByIdData(2))
                    .Returns(_fakes.GetAlunosByIdFake(2));

                var ctlr = mock.Create<AlunosController>();
                var expected = _fakes.GetAlunosByIdFake(2);
                var actual = ctlr.GetAlunosById(2);

                Assert.True(actual != null);
                Assert.Equal(expected, actual.Value);
            }
        }
        #endregion

        #region PostAlunos_ThirdTeste
        [Fact]
        public void PostAlunos_ValidarCriacao()
        {
            using (var mock = AutoMock.GetLoose())
            {                
                int idAlunoFake = 1;
                var aluno = _fakes.GetAlunosByIdFake(idAlunoFake);
                mock.Mock<IAlunosRepository>()
                    .Setup(x => x.PostAlunoData(aluno));

                var ctlr = mock.Create<AlunosController>();
                ctlr.PostAlunos(aluno);

                //Verifica se o Método no Repositório Foi Executado!
                mock.Mock<IAlunosRepository>()
                    .Verify(x => x.PostAlunoData(aluno), Times.Exactly(1));
            }
        }
        #endregion

        #region PutAlunos_FourthTeste
        [Fact]
        public void PutAlunos_ValidarEdicao()
        {
            using (var mock = AutoMock.GetLoose())
            {
                int idAlunoFake = 3;
                var aluno = _fakes.GetAlunosByIdFake(idAlunoFake);
                mock.Mock<IAlunosRepository>()
                    .Setup(x => x.PostAlunoData(aluno));

                var ctlr = mock.Create<AlunosController>();
                ctlr.PutAlunos(aluno.Id, aluno);

                //Verifica se o Método no Repositório Foi Executado!
                mock.Mock<IAlunosRepository>()
                    .Verify(x => x.PutAlunoData(aluno), Times.Exactly(1));
            }
        }
        #endregion

        #region DeleteAlunos_FifthTeste
        [Fact]
        public void DeleteAlunos_ValidarExclusao()
        {
            using (var mock = AutoMock.GetLoose())
            {
                int idAlunoFake = 4;
                mock.Mock<IAlunosRepository>()
                    .Setup(x => x.GetAlunosByIdData(idAlunoFake))
                    .Returns(new Alunos() { });
                mock.Mock<IAlunosRepository>()
                    .Setup(x => x.DeleteAlunoData(It.IsAny<Alunos>()));

                var ctlr = mock.Create<AlunosController>();
                ctlr.DeleteAlunos(idAlunoFake);

                //Verifica se o Método no Repositório Foi Executado!
                mock.Mock<IAlunosRepository>()
                    .Verify(x => x.DeleteAlunoData(It.IsAny<Alunos>()), Times.Once);
            }
        }
        #endregion
    }
}
