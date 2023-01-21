using MarketPalceManagement.Account.Abstractions;
using MarketPalceManagement.Account.Models;
using MarketPalceManagement.Account.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MarketPalceManagement.Account;

public static class ServiceCollectionExtensions
{
    private static AccessTokenConfiguration _options;

    public static IServiceCollection AddAccountServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AccessTokenConfiguration>(configuration.GetSection(nameof(AccessTokenConfiguration)));

        var serviceProvider = services.BuildServiceProvider();
         _options = serviceProvider.GetRequiredService<IOptions<AccessTokenConfiguration>>().Value;

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer=_options.Issuer,
                ValidAudience=_options.Audience,
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key)),
                ValidateIssuer=true,
                ValidateAudience=true,
                ValidateLifetime=false,
                ValidateIssuerSigningKey=true
            };
        });        

        services.AddScoped<IAuthenticationCreator, AuthenticationCreator>();
        services.AddScoped<IUserAuthentication, UserAuthentication>();

        return services;
    }
}
