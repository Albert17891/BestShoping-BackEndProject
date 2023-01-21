using MarketplaceManagement.Domain.Account;
using MarketplaceManagement.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Infastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ApplicationConnection")));

        services.AddIdentity<AppUser, Microsoft.AspNetCore.Identity.IdentityRole>()
            .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
