using Microsoft.Extensions.Options;
using SocialNetwork.Core.Helper;
using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.DTOs.Auth;
using SocialNetwork.Domain.Entities;
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

        public async Task<Response<RegistrationResponse>> RegisterAsync(RegistrationRequest registration)
        {
            var person =await _authRepository.GetPersonByEmailAsync(registration.Email);
            if (person != null)
                return new Response<RegistrationResponse>
                {
                    Success = false,
                    Message = "Email already exist",
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

            return new Response<RegistrationResponse>
            {
                Success = true,
                Message = "registraion successful",
                Result = new RegistrationResponse
                {
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Email = registration.Email.ToLower(),
                }
            };
        }

        public async Task<Response<LoginResponse>> LoginAsync(LoginRequest loginRequest)
        {
            Response<LoginResponse> response = new();
            var person = await _authRepository.GetPersonByEmailAsync(loginRequest.Email);

            if (person == null || !AuthHelper.HashPassword(loginRequest.Password).Equals(person.Password))
            {
                response.Success = false;
                response.Message = "Invalid email or password";
                return response;
            }
            string token = _jwtConfigurationOptions.GenerateJwtAsync(person.Email, person.Id);
            response.Result = new LoginResponse
            {
                AccessToken = token,
                User = new Domain.DTOs.Person
                {
                    Email = person.Email,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                }
            };
            response.Success = true;
            response.Message = "Login successful";
            return response;
        }

    }
}
