using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Interfaces.Repositories
{
    /// <summary>
    /// get person details by email
    /// </summary>
    public interface IAuthRepository:IRepository<Person>
    {
        Task<Person> GetPersonByEmailAsync(string email);
    }
}
