using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Domain.Persistence.Context
{
    public class SocialNetworkDbContext:DbContext
    {
        public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> dbContext):base(dbContext)
        {

        }
    }
}
