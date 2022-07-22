using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Interfaces.Repositories
{
    public interface IPageRepository:IRepository
    {
        Task<Page> GetPageAsync(long pageId, long userId);
    }
}
