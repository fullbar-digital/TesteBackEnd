namespace Business
{
    public static class VerificadorAprovacao
    {
        public static string IsAprovado(double nota, double notaMinimaAprovacao)
        {
            if (nota >= notaMinimaAprovacao)
                return "aprovado";
            return "reprovado";
        }
    }
}
