using MarketplaceManagement.ProductService.Abstractions;
using MarketplaceManagement.ProductService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarketplaceManagement.ProductService;

public static class ServcieCollectionExtensions
{
    public static IServiceCollection AddProductServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductServices>();

        return services;
    }
}
