using MarketPalceManagement.Account.Abstractions;
using MarketPalceManagement.Account.Models;
using Microsoft.AspNetCore.Identity;

namespace MarketPalceManagement.Account.Services;

public class UserAuthentication : IUserAuthentication
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IAuthenticationCreator _authenticationCreator;

    public UserAuthentication(UserManager<AppUser> userManager, IAuthenticationCreator authenticationCreator)
    {
        _userManager = userManager;
        _authenticationCreator = authenticationCreator;
    }
    public async Task<string> AuthenticateAsync(LoginServiceModel login)
    {
        string token = null;

        var user = await _userManager.FindByNameAsync(login.UserName);

        if (user == null)
        {
            throw new NullReferenceException("User Not Found");
        }

        var checkResult = await _userManager.CheckPasswordAsync(user, login.Password);

        if (checkResult)
        {
            token = _authenticationCreator.CreateToken(login.UserName);
        }

        return token;
    }
}
