using SocialNetwork.Domain.Common;

namespace SocialNetwork.Interfaces.Services
{
    public interface IFollowService
    {
        Task<Response<long>> FollowePageAsync(long pageId, long userId);
        Task<Response<long>> FollowePersonAsync(long personId, long userId);
    }
}
