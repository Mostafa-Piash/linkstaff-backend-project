namespace SocialNetwork.Interfaces.Repositories
{
    public interface IRepository 
    {
        /// <summary>
        /// get all data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync<T>() where T : class;
        /// <summary>
        /// get range data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync<T>(int index, int count) where T : class;
        /// <summary>
        /// get total rows
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<int> GetTotalRowsAsync<T>() where T : class;
        /// <summary>
        /// get data by id
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync<TKey,T>(TKey id) where T : class;
        /// <summary>
        /// create data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync<T>(T entity) where T : class;
        /// <summary>
        /// update data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync<T>(T entity) where T : class;
        /// <summary>
        /// commit changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
