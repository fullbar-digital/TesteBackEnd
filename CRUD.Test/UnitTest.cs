using System.Collections.Generic;
using System.Linq;
using CRUD.API;
using CRUD.BLL;
using CRUD.BLL.Interfaces;
using CRUD.DAL.Interfaces;
using CRUD.Model;
using CRUD.ViewModel;
using Moq;
using NUnit.Framework;

namespace CRUD.Test
{
    public class Tests
    {


        [Test]
        public void TestGetAll()
        {
            var mock = new Mock<IAlunoBusiness>();

            List<AlunoViewModel> list = new List<AlunoViewModel>();
            list.Add(new AlunoViewModel()
            {
                id = "1",
                curso = "TI",
                nome = "reinaldo",
                nota = "8",
                periodo = "1",
                registroAcademico = "12345",
            });
            list.Add(new AlunoViewModel()
            {
                id = "2",
                curso = "TI",
                nome = "joão",
                nota = "5",
                periodo = "1",
                registroAcademico = "25255",
            });

            mock.Setup(p => p.GetAll()).Returns(list);
            AlunoController home = new AlunoController(mock.Object);
            List<AlunoViewModel> result = home.Get();
            Assert.AreEqual(list, result);
            Assert.Pass();
        }

        [Test]
        public void TestGetById()
        {
            var mock = new Mock<IAlunoBusiness>();

            AlunoViewModel item = new AlunoViewModel()
            {
                id = "2",
                curso = "TI",
                nome = "joão",
                nota = "5",
                periodo = "1",
                registroAcademico = "25255",
            };

            mock.Setup(p => p.GetById(2)).Returns(item);
            AlunoController home = new AlunoController(mock.Object);
            AlunoViewModel result = home.Get(2);
            Assert.AreEqual(item, result);
            Assert.Pass();
        }

        [Test]
        public void TestGetFilter()
        {
            var mock = new Mock<IAlunoRepository>();

            List<Aluno> list = new List<Aluno>();
            list.Add(new Aluno()
            {
                Id = 1,
                Curso = "TI",
                Nome = "reinaldo",
                Nota = 8,
                Periodo = 1,
                RA = "12345",
            });
            FilterViewModel filtro = new FilterViewModel() { status = "aprovado" };
            mock.Setup(p => p.GetByFilter(filtro)).Returns(list);
            AlunoBusiness business = new AlunoBusiness(mock.Object);
            List<AlunoViewModel> result = business.GetByFilter(filtro);
            
            Assert.AreEqual(list.FirstOrDefault().Id.ToString(), result.FirstOrDefault().id);
            Assert.Pass();
        }

        [Test]
        public void TestSave()
        {
            var mock = new Mock<IAlunoBusiness>();

            AlunoViewModel item = new AlunoViewModel()
            {
                curso = "TI",
                nome = "reinaldo",
                nota = "8",
                periodo = "1",
                registroAcademico = "12345",
            };

            mock.Setup(p => p.Save(item)).Returns(true);
            AlunoController home = new AlunoController(mock.Object);

            bool result = home.Post(item);

            Assert.AreEqual(true, result);
            Assert.Pass();
        }
    }
}