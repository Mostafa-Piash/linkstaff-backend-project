using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Interfaces.Repositories
{
    public interface IAuthRepository:IRepository<Person>
    {
        Task<Person> GetPersonByEmailAsync(string email);
    }
}
