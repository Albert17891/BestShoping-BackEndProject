using MarketPalceManagement.Account.Abstractions;
using MarketPalceManagement.Account.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketPalceManagement.Account.Services;

public class AuthenticationCreator : IAuthenticationCreator
{
    private readonly AccessTokenConfiguration _options;

    public AuthenticationCreator(IOptions<AccessTokenConfiguration> options)
    {
        _options = options.Value;
    }

    public BinaryReader JwtRegisteretClaimNames { get; private set; }

    public string CreateToken(string userName)
    {
        

        var issuer = _options.Issuer;
        var audience = _options.Audience;
        var key = Encoding.UTF8.GetBytes(_options.Key);
        var expiresMinutes = _options.AccessTokenExpiresMinutes;

        var securityTokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, userName),
                new Claim(JwtRegisteredClaimNames.Email, userName)
            }),

            Expires = DateTime.Now.AddMinutes(expiresMinutes),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(securityTokenDescriptor);
        var accessToken = tokenHandler.WriteToken(token);

        return accessToken;
    }
}
