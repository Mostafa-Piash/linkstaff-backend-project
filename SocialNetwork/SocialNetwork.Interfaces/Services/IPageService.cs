using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Model.Page;
using SocialNetwork.Domain.Model.Post;

namespace SocialNetwork.Interfaces.Services
{
    public interface IPageService
    {
        Task<Response<string>> CreatePageAsync(PageRequestModel pageRequest, long userId);
        Task<Response<long>> PostPageStatusAsync(long pageId, long userId, PostRequestModel postRequest);
    }

}
