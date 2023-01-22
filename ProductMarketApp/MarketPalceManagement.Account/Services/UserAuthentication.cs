using Mapster;
using MarketPalceManagement.Account.Abstractions;
using MarketPalceManagement.Account.Models;
using MarketplaceManagement.Domain.Account;
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

    public async Task<string> RegisterAsync(RegisterServiceModel registerServiceModel)
    {
        var user = registerServiceModel.Adapt<AppUser>();

      var result=  await _userManager.CreateAsync(user, registerServiceModel.Password);

        if (!result.Succeeded)
        {
            throw new Exception("Failed to Register");
        }

        return user.Id;
    }
}
