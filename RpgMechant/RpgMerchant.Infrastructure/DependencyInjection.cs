using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpgMerchant.Application.Common.Interfaces;
using RpgMerchant.Infrastructure.EntityFrameworkCore;

namespace RpgMerchant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<MerchantDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Merchant"),
                builder => builder.MigrationsAssembly(typeof(MerchantDbContext).Assembly.FullName)));
        

        return services;
    }
    
    

    
}