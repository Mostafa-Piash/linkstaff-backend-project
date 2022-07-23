using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Extensions;
using SocialNetwork.Domain.Model.Page;
using SocialNetwork.Domain.Model.Post;
using SocialNetwork.Interfaces.Services;

namespace SocialNetwork.API.Controllers
{
    [Route("api/page")]
    [ApiController]
    [Authorize]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePageAsync([FromBody] PageRequestModel request)
        {
            long userId = await HttpContext.GetUserIdFromTokenAsync();
            var response = await _pageService.CreatePageAsync(request, userId);
            if (response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpPost("{pageId}/attach-post")]
        public async Task<IActionResult> PostPageStatusAsync(long pageId, [FromBody] PostRequestModel request)
        {
            long userId = await HttpContext.GetUserIdFromTokenAsync();
            var response = await _pageService.PostPageStatusAsync(pageId, userId, request);
            if (response.Success)
                return Ok(response);
            return StatusCode(StatusCodes.Status400BadRequest, response);
        }
    }
}
