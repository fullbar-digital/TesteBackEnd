using AppAlunos.Api.V1;
using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace AppAlunos.Test.Controllers
{
    [TestClass]
    public class AlunoControllerTest
    {
        private AlunoController _alunoController;
        private Mock<IAlunoService> _alunoService;
        private Mock<IMapper> _mapper;
        private Mock<INotificador> _notificador;

        [TestInitialize]
        public void Initialize()
        {
            _alunoService = new Mock<IAlunoService>();
            _mapper = new Mock<IMapper>();
            _notificador = new Mock<INotificador>();

            _alunoController = new AlunoController(_alunoService.Object, _mapper.Object, _notificador.Object);

        }

        [TestMethod]
        public void AlunoController_ListarTodos()
        {
            _alunoService.Setup(x => x.ListarAlunos()).Returns(new List<AlunoResponse>());

            ActionResult<IEnumerable<AlunoResponse>> result = _alunoController.ListarAlunos();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AlunoController_ListarTodosException()
        {
            _alunoService.Setup(x => x.ListarAlunos()).Throws(new Exception());

            ActionResult<IEnumerable<AlunoResponse>> result = _alunoController.ListarAlunos();

            Assert.IsNotNull(result);
        }
    }
}
