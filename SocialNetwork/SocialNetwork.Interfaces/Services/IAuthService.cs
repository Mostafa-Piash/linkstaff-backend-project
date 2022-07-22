using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Model.Auth;

namespace SocialNetwork.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Response<LoginResponseModel>> LoginAsync(LoginRequestModel loginRequest);
        Task<Response<RegistrationResponseModel>> RegisterAsync(RegistrationRequestModel registration);
    }
}
