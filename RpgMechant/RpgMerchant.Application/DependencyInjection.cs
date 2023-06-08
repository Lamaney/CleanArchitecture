using Microsoft.Extensions.DependencyInjection;
using RpgMerchant.Application.Common.Interfaces.Item;
using RpgMerchant.Application.Services.Item;

namespace RpgMerchant.Application;

public static class DependencyInjection
{
     public static IServiceCollection AddApplication(this IServiceCollection services)
     {
          services.AddScoped<IItemService, ItemService>();
          return services;
     }
}