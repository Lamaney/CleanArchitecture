using RpgMerchant.Domain.Models;
using RpgMerchant.Domain.Repositories.Interfaces;
using RpgMerchant.Infrastructure.Data.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure.Data.Repositories;

public class ItemRepository:Repository<Item>,IItemRepository
{
    public ItemRepository(MerchantDbContext dbContext) : base(dbContext)
    {
    }
}