using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Interfaces.Repositories
{
    public interface IPostRepository:IRepository<Post>
    {
        Task<IEnumerable<PostDto>> GetFeedPostsAsync(long userId);
    }
}
