using FullbarDigital.CadastroDeAlunos.Dominio;
using FullbarDigital.CadastroDeAlunos.Dominio.Interfaces;
using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FullbarDigital.CadatroDeAlunos.Teste.Dominio
{
    public class AlunoServiceTeste
    {
        Mock<IAlunoRepository> _alunoRepositoryMock;

        AlunoService _alunoService;
        public AlunoServiceTeste()
        {
            _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoService = new AlunoService(_alunoRepositoryMock.Object);
        }

        [Fact]
        public void UpdateHistorico_DeveReceberUmHistorico_AtualizarStatusParaAprovado_SeANotaForMaiorIgualACadastradaNaDiciplina()
        {
            var request = new Historico();
            request.Nota = 8;

            var response = new Diciplina();
            response.NotaMinima = 7;

            _alunoRepositoryMock.Setup(_ => _.GetDiciplina(It.IsAny<long>())).Returns(response);

            _alunoService.UpdateHistorico(request);

            _alunoRepositoryMock.Verify(_ => _.UpdateHistorico(It.Is<Historico>(x => x.Status == "Aprovado")), Times.Once);
        }

        [Fact]
        public void UpdateHistorico_DeveReceberUmHistorico_AtualizarStatusParaReprovado_SeANotaForMenorIgualACadastradaNaDiciplina()
        {
            var request = new Historico();
            request.Nota = 5;

            var response = new Diciplina();
            response.NotaMinima = 7;

            _alunoRepositoryMock.Setup(_ => _.GetDiciplina(It.IsAny<long>())).Returns(response);

            _alunoService.UpdateHistorico(request);

            _alunoRepositoryMock.Verify(_ => _.UpdateHistorico(It.Is<Historico>(x => x.Status == "Reprovado")), Times.Once);
        }
    }
}
