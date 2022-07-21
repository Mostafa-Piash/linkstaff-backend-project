using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.API.Extensions;

namespace SocialNetwork.API.Controllers
{
    [Route("api/page")]
    [ApiController]
    [Authorize]
    public class PageController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            long userId = await HttpContext.GetUserIdFromTokenAsync();
            return Ok(userId);
        }
    }
}
