using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Extensions;
using SocialNetwork.Domain.Model.Post;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.API.Controllers
{
    [Route("api/person")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("attach-post")]
        public async Task<IActionResult> PostStatusAsync([FromBody] PostRequestModel request)
        {
            long userId = await HttpContext.GetUserIdFromTokenAsync();
            var response = await _personService.PostStatusAsync(userId, request);
            if (response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpGet("feed")]
        public async Task<IActionResult> PostStatusAsync()
        {
            long userId = await HttpContext.GetUserIdFromTokenAsync();
            var response = await _personService.GetFeedPostsAsync(userId);
            if (response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }
    }
}
