using System;

namespace Template.Api.ApplicationCore.Dto
{
    public class AuthorizationTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}