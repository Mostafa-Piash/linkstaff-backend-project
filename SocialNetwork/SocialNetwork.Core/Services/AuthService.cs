using Microsoft.Extensions.Options;
using SocialNetwork.Core.Constants;
using SocialNetwork.Core.Helper;
using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Model.Auth;
using SocialNetwork.Domain.Model.Person;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        private readonly JwtConfiguration _jwtConfigurationOptions;
        public AuthService(IAuthRepository authRepository, IOptions<JwtConfiguration> jwtConfigurationOptions)
        {
            _authRepository = authRepository;
            _jwtConfigurationOptions = jwtConfigurationOptions?.Value;
        }

        public async Task<Response<RegistrationResponseModel>> RegisterAsync(RegistrationRequestModel registration)
        {
            var person = await _authRepository.GetPersonByEmailAsync(registration.Email);
            if (person != null)
                return new Response<RegistrationResponseModel>
                {
                    Success = false,
                    Message = ReposneMessageConstant.EMAIL_EXIST,
                    Result = null
                };

            await _authRepository.CreateAsync(new Person
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.Email.ToLower(),
                Password = AuthHelper.HashPassword(registration.Password)
            });
            await _authRepository.SaveChangesAsync();

            return new Response<RegistrationResponseModel>
            {
                Success = true,
                Message = ReposneMessageConstant.REGISTRAION_SUCCESSFUL,
                Result = new RegistrationResponseModel
                {
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Email = registration.Email.ToLower(),
                }
            };
        }

        public async Task<Response<LoginResponseModel>> LoginAsync(LoginRequestModel loginRequest)
        {
            Response<LoginResponseModel> response = new();
            var person = await _authRepository.GetPersonByEmailAsync(loginRequest.Email);

            if (person == null || !AuthHelper.HashPassword(loginRequest.Password).Equals(person.Password))
            {
                response.Success = false;
                response.Message = ReposneMessageConstant.INVALID_CREDENTIALS;
                return response;
            }
            string token = _jwtConfigurationOptions.GenerateJwtAsync(person.Email, person.Id);
            response.Result = new LoginResponseModel
            {
                AccessToken = token,
                User = new PersonModel
                {
                    Email = person.Email,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                }
            };
            response.Success = true;
            response.Message = ReposneMessageConstant.LOGIN_SUCCESSFUL;
            return response;
        }

    }
}
