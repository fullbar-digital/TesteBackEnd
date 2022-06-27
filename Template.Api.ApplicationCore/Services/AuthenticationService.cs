using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Dto;
using Template.Api.ApplicationCore.Intefaces;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.ApplicationCore.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthSettings _appSettings;
        public AuthenticationService(IOptions<AuthSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<AuthorizationTokenDto> AuthenticateAsync()
        {
            //TODO: implement database authentication

            var JWT = BuildTokenAuthentication();

            return await Task.FromResult(new AuthorizationTokenDto()
            {
                Token = JWT,
                Expiration = DateTime.UtcNow
            });
        }

        private string BuildTokenAuthentication()
        {
            var identity = new ClaimsIdentity();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var newToken = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Subject = identity,
                Expires = DateTime.UtcNow.AddSeconds(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(newToken);
        }
    }
}
