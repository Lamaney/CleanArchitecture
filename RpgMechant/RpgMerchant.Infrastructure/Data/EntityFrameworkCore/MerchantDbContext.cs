using Microsoft.EntityFrameworkCore;
using RpgMerchant.Application.Common.Interfaces;
using RpgMerchant.Domain.Models;
using RpgMerchant.Infrastructure.Data.Configurations;

namespace RpgMerchant.Infrastructure.Data.EntityFrameworkCore;

public class MerchantDbContext:DbContext,IMerchantDbContext
{
    public DbSet<Item> Items { get; set; }
  
    public MerchantDbContext(DbContextOptions<MerchantDbContext> options):base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ItemConfiguration());
    }

  
}