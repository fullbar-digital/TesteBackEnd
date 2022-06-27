using System.Threading.Tasks;
using Template.Api.ApplicationCore.Dto;

namespace Template.Api.ApplicationCore.Intefaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthorizationTokenDto> AuthenticateAsync();
    }
}
