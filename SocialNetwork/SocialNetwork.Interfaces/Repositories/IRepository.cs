namespace SocialNetwork.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// get all data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync();
        /// <summary>
        /// get range data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync(int index, int count);
        /// <summary>
        /// get total rows
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<int> GetTotalRowsAsync();
        /// <summary>
        /// get data by id
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync<TKey>(TKey id);
        /// <summary>
        /// create data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task CreateAsync(T entity);
        /// <summary>
        /// update data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// commit changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
