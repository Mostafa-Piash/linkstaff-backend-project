using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Interfaces.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// Get feeds of people and pages followed by the user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<PostDto>> GetFeedPostsAsync(long userId);
    }
}
