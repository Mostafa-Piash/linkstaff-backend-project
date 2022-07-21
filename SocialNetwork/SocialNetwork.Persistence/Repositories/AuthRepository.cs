using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Persistence.Repositories
{
    public class AuthRepository : Repository, IAuthRepository
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
