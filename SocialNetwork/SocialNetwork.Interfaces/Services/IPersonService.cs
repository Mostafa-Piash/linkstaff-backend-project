using SocialNetwork.Domain.Common;
using SocialNetwork.Domain.Model.Post;

namespace SocialNetwork.Interfaces.Services
{
    public interface IPersonService
    {
        Task<Response<IEnumerable<PostResponseModel>>> GetFeedPostsAsync(long userId);
        Task<Response<long>> PostStatusAsync(long userId, PostRequestModel postRequest);
    }

}
