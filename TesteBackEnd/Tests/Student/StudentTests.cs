using System;
using ApplicationCore.Domain.Component;
using Xunit;

namespace Tests.Student
{
    public class StudentTests
    {
        [Fact]
        public void Deve_Criar_Instancia_Do_Aluno_Valido()
        {
            var now = DateTime.Now;
            var period = new Period {Start = now, End = now.AddYears(1)};

            var student = new ApplicationCore.Domain.Student(1, 4, "Flavio", "102030", period, 8, true);

            Assert.Equal(1, student.Id);
            Assert.Equal("Flavio", student.Name);
            Assert.Equal("102030", student.Ra);
            Assert.Equal(now, student.Period.Start);
            Assert.Equal(now.AddYears(1), student.Period.End);
            Assert.Equal(8, student.Grade);
            Assert.True(student.Status);
        }

        [Fact]
        public void Deve_Validar_Aluno_E_Disparar_Excecao_Se_Instancia_Invalida()
        {
            var student = new ApplicationCore.Domain.Student(0, 0, "", "", new Period(), 0, false);
            Assert.Throws(typeof(FluentValidation.ValidationException), () => student.Validate());
        }
    }
}