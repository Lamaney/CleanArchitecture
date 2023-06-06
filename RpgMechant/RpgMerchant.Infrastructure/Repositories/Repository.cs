using Microsoft.EntityFrameworkCore;
using RpgMerchant.Domain.Repositories.Interfaces;
using RpgMerchant.Infrastructure.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{

    private readonly DbContext _context;
    private readonly DbSet<T> _set;

    public Repository(DbContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _set.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _set.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _set.Update(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _set.Remove(entity);
    }
}