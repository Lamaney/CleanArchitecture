using RpgMerchant.Domain.Common.Interfaces;
using RpgMerchant.Infrastructure.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure.Repositories;

public class UnitOfWork:IUnitOfWork
{
    private readonly MerchantDbContext _dbContext;

    public UnitOfWork(MerchantDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}