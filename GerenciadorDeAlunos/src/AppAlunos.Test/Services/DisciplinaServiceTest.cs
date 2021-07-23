using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace AppAlunos.Test.Services
{
    [TestClass]
    public class DisciplinaServiceTest
    {
        private DisciplinaService service;
        private Mock<IDisciplinaRepository> _disciplinaRepository;
        private Mock<INotificador> _notificador;
        static readonly Task SuccessTask = Task.FromResult<object>(null);

        [TestInitialize]
        public void Initialize()
        {
            _disciplinaRepository = new Mock<IDisciplinaRepository>();
            _notificador = new Mock<INotificador>();

            service = new DisciplinaService(_disciplinaRepository.Object, _notificador.Object);
        }

        [TestMethod]
        public void AdicionarTest()
        {
            _disciplinaRepository.Setup(x => x.Adicionar(It.IsAny<Disciplina>())).Returns(SuccessTask);

            var result = service.Adicionar(new Disciplina());

            Assert.AreEqual(result.Result, true);
        }
    }
}
