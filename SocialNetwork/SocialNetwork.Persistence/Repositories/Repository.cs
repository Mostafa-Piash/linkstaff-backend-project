using Microsoft.EntityFrameworkCore;
using SocialNetwork.Interfaces.Repositories;
using SocialNetwork.Persistence.Context;

namespace SocialNetwork.Persistence.Repositories
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected readonly SocialNetworkDbContext _context;
        public Repository(SocialNetworkDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(int index, int count)
        {
            return await _context.Set<T>().Skip(index).Take(count).ToListAsync();
        }

        public async Task<int> GetTotalRowsAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<T> GetByIdAsync<TKey>(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
