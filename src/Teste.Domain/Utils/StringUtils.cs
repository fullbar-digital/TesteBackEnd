namespace Teste.Domain.Utils
{
    public static class StringUtils
    {
        public static bool IsValidGuid(this string guid)
        {
            return Guid.TryParse(guid, out _);
        }
    }
}
