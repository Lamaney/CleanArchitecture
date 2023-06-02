using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpgMerchant.Application.Common.Interfaces;
using RpgMerchant.Domain.Common.Interfaces;
using RpgMerchant.Domain.Repositories.Interfaces;
using RpgMerchant.Infrastructure.EntityFrameworkCore;
using RpgMerchant.Infrastructure.Repositories;

namespace RpgMerchant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<MerchantDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Merchant"),
                builder => builder.MigrationsAssembly(typeof(MerchantDbContext).Assembly.FullName)));

        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
    
    

    
}