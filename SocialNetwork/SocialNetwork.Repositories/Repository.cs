using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Persistence.Context;
using SocialNetwork.Interfaces.Repositories;

namespace SocialNetwork.Repositories
{
    public class Repository : IRepository
    {
        private readonly SocialNetworkDbContext _context;
        public Repository(SocialNetworkDbContext context)
        {
            _context = context;
        }
       
        public async Task<ICollection<T>> GetAllAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync<T>(int index, int count) where T : class
        {
            return await _context.Set<T>().Skip(index).Take(count).ToListAsync();
        }

        public async Task<int> GetTotalRowsAsync<T>() where T : class
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<T> GetByIdAsync<TKey, T>(TKey id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
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
