using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RpgMerchant.Application.Common.Interfaces;
using RpgMerchant.Domain.Common.Interfaces;
using RpgMerchant.Domain.Repositories.Interfaces;
using RpgMerchant.Infrastructure.Data.EntityFrameworkCore;
using RpgMerchant.Infrastructure.Data.Repositories;

namespace RpgMerchant.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<MerchantDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Merchant"),
                    builder => builder.MigrationsAssembly(typeof(MerchantDbContext).Assembly.FullName)),
            ServiceLifetime.Scoped);

        services.AddScoped<IMerchantDbContext>(provider => provider.GetRequiredService<MerchantDbContext>());
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(typeof(DependencyInjection));
        
        return services;
    }
    
    

    
}