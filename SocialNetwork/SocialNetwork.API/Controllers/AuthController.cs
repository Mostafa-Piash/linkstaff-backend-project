﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Domain.DTOs.Auth;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegistrationRequest request)
        {
            var response = await _authService.RegisterAsync(request);
            if(response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);
            if (response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response.Message);
        }

    }
}