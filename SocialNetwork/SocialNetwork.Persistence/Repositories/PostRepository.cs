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
                       from pages in _context.Pages
                       where (posts.CreatedByPerson == followers.PersonId || posts.CreatedByPerson==userId || posts.CreatedByPage == followers.PageId)
                      // && (posts.CreatedByPerson == people.Id || posts.CreatedByPage == pages.Id)
                       && followers.FollowerId == userId && posts.IsActive &&  !posts.IsDeleted
                       select  new PostDto
                       {
                           PostId = posts.Id,
                           Status = posts.Status,
                           CreatedDate = posts.CreatedDate,
                           CreatedByPerson = posts.CreatedByPerson!=null? string.Format("{0} {1}", people.FirstName, people.LastName): string.Empty,
                           CreatedByPage = posts.CreatedByPage != null ? string.Format("{0}", pages.Name) : string.Empty
                       };

            return await query.GroupBy(x=>x.PostId).Select(s=>s.FirstOrDefault()).ToListAsync();
        }
    }
}
