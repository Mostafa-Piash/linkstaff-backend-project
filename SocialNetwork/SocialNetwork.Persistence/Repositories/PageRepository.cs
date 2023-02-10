using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Persistence.Context;

namespace SocialNetwork.Persistence.Repositories
{
    public class PageRepository : Repository<Page>, IPageRepository
    {
        public PageRepository(SocialNetworkDbContext context) : base(context)
        {
        }
        public async Task<Page> GetPageAsync(long pageId, long userId)
        {
            return await _context.Pages.FirstOrDefaultAsync(p => p.Id == pageId && p.CreatorId == userId && p.IsActive && !p.IsDeleted);
        }
    }
}
