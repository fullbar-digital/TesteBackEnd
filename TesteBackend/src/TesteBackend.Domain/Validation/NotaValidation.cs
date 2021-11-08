using TesteBackend.Domain.Models;

namespace TesteBackend.Domain.Validation
{
    internal static class NotaValidation
    {
        internal static StatusResult Validate(decimal nota, decimal notaMinimaAprovacao)
        {
            if (nota >= notaMinimaAprovacao)
                return StatusResult.Aprovado;
            else
                return StatusResult.Reprovado;
        }
    }
}
