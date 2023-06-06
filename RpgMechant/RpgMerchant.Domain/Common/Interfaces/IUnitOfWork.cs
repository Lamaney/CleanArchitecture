using RpgMerchant.Domain.Repositories.Interfaces;

namespace RpgMerchant.Domain.Common.Interfaces;

public interface IUnitOfWork:IDisposable
{
    Task CommitAsync();
    void Rollback();
    IRepository<T> GetRepository<T>() where T : class;
    
  
}