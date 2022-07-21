using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Interfaces.Repositories
{
    public interface IAuthRepository:IRepository
    {
        Task<Person> GetPersonByEmailAsync(string email);
    }
}
