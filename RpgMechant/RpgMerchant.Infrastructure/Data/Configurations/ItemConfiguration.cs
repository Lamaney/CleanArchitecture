using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgMerchant.Domain.Models;

namespace RpgMerchant.Infrastructure.Data.Configurations;

public class ItemConfiguration:IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("items");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(250);
        
    }
}