using Business;
using NUnit.Framework;

namespace Test
{
    public class Testes
    {
        [TestCase(9.0, 6.0, "aprovado")]
        [TestCase(5.0, 6.0, "reprovado")]
        public void Teste_Aluno_Aprovado_Reprovado(double first, double second, string expected_result)
        {
            var result = VerificadorAprovacao.IsAprovado(first, second);
            Assert.AreEqual(result, expected_result);
        }
    }
}
