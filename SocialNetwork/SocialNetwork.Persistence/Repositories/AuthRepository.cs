using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Persistence.Context;

namespace SocialNetwork.Persistence.Repositories
{
    public class AuthRepository : Repository<Person>, IAuthRepository
    {
        public AuthRepository(SocialNetworkDbContext context) : base(context)
        {
        }

        public async Task<Person>GetPersonByEmailAsync(string email)
        {
            return await _context.People.FirstOrDefaultAsync(x=>x.Email==email.ToLower()
                                                             && x.IsActive
                                                             && !x.IsDeleted);
        }
    }
}
