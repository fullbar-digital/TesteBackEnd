namespace Template.Api.ApplicationCore.Intefaces
{
    public class AuthSettings
    {
        public string SecretKey { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}