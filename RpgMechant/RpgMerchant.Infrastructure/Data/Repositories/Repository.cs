using Microsoft.EntityFrameworkCore;
using RpgMerchant.Domain.Repositories.Interfaces;

namespace RpgMerchant.Infrastructure.Data.Repositories;

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

    public async Task<T> GetByIdAsync(long id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<T> InsertAsync(T entity)
    {
        var addedEntity = await _context.Set<T>().AddAsync(entity);
        return addedEntity.Entity;
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