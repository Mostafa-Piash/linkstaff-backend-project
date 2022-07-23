using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Extensions;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.API.Controllers
{
    [Route("api/follow")]
    [ApiController]
    [Authorize]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost("person/{personId}")]
        public async Task<IActionResult> FollowePersonAsync(long personId)
        {
            long userId = await HttpContext.GetUserIdFromTokenAsync();
            var response = await _followService.FollowePersonAsync(personId, userId);
            if (response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpPost("page/{pageId}")]
        public async Task<IActionResult> FollowePageAsync(long pageId)
        {
            long userId = await HttpContext.GetUserIdFromTokenAsync();
            var response = await _followService.FollowePageAsync(pageId, userId);
            if (response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }
    }
}
