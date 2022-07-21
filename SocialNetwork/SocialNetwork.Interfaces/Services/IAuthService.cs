using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.DTOs.Auth;

namespace SocialNetwork.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Response<LoginResponse>> LoginAsync(LoginRequest loginRequest);
        Task<Response<RegistrationResponse>> RegisterAsync(RegistrationRequest registration);
    }
}
