using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RpgMerchant.Infrastructure.Data.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure;

public class MerchantDbContextFactory:IDesignTimeDbContextFactory<MerchantDbContext>
{
   
    public MerchantDbContext CreateDbContext(string[] args)
    {
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RpgMerchant.API/"))
            .AddJsonFile("appsettings.json", optional: false).Build();
       
       

        var builder = new DbContextOptionsBuilder<MerchantDbContext>();
        var connectionString = configuration.GetConnectionString("Merchant");
        builder.UseSqlServer(connectionString);

        return new MerchantDbContext(builder.Options);
    }
}