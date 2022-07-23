using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Interfaces.Repositories
{
    /// <summary>
    /// get page by page and user id
    /// </summary>
    public interface IPageRepository:IRepository<Page>
    {
        Task<Page> GetPageAsync(long pageId, long userId);
    }
}
