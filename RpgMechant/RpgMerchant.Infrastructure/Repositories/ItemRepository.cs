using RpgMerchant.Domain.Models;
using RpgMerchant.Domain.Repositories.Interfaces;
using RpgMerchant.Infrastructure.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure.Repositories;

public class ItemRepository:GenericRepository<Item>,IItemRepository
{
    public ItemRepository(MerchantDbContext dbContext) : base(dbContext)
    {
    }
}