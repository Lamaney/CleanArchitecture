using Microsoft.EntityFrameworkCore;
using RpgMerchant.Domain.Repositories.Interfaces;
using RpgMerchant.Infrastructure.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
   
{

    private readonly MerchantDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(MerchantDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public  IQueryable GetQueryableAsync()
    {
        return  _dbSet.AsQueryable();
    }
}