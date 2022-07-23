using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.DTOs;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Persistence.Context;

namespace SocialNetwork.Persistence.Repositories
{
    public class PostRepository : Repository<Post>,IPostRepository
    {
        public PostRepository(SocialNetworkDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PostDto>> GetFeedPostsAsync(long userId)
        {
           var query = from posts in _context.Posts
                       from followers in _context.Followers
                       from people in _context.People 
                       where (posts.CreatedByPerson == followers.PersonId || posts.CreatedByPage == followers.PageId)
                       && (posts.CreatedByPerson == people.Id || posts.CreatedByPage == people.Id)
                       && followers.FollowerId == userId && posts.IsActive &&  !posts.IsDeleted
                       select new PostDto
                       {
                           Status = posts.Status,
                           CreatedDate = posts.CreatedDate,
                           CreatedBy =string.Format("{0} {1}", people.FirstName, people.LastName)
                       };

            return await query.ToListAsync();
        }
    }
}
