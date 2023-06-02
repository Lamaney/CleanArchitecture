namespace RpgMerchant.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
    void Dispose();
}