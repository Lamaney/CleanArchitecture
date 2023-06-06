using Microsoft.EntityFrameworkCore;
using RpgMerchant.Domain.Common.Interfaces;
using RpgMerchant.Domain.Repositories.Interfaces;
using RpgMerchant.Infrastructure.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly MerchantDbContext _context;
    private readonly Dictionary<Type, object> _repositories;

    public UnitOfWork(MerchantDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public async Task CommitAsync()
    {
        await using var dbContextTransaction = await _context.Database.BeginTransactionAsync();

        try
        {
            await _context.SaveChangesAsync();
            await dbContextTransaction.CommitAsync();
        }
        catch (Exception e)
        {
            Rollback();
            throw new Exception(e.Message, e.InnerException);
        }
    }

    public void Rollback()
    {
        _context.Database.CurrentTransaction?.Rollback();
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        if (_repositories.TryGetValue(typeof(T), out var value))
        {
            return (IRepository<T>)value;
        }

        var repository = new Repository<T>(_context);
        _repositories.Add(typeof(T), repository);
        return repository;
    }
    
    


    private bool _disposedValue = false;

    private void Dispose(bool disposing)
    {
        if (_disposedValue) return;

        if (disposing)
        {
            _context.Dispose();
        }

        _disposedValue = true;
    }


    public void Dispose()
    {
        Dispose(true);
    }
    
}