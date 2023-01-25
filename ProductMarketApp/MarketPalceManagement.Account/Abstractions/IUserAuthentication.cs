using MarketPalceManagement.Account.Models;

namespace MarketPalceManagement.Account.Abstractions;

public interface IUserAuthentication
{
    public Task<string> AuthenticateAsync(LoginServiceModel login);
    public Task<string> RegisterAsync(RegisterServiceModel registerServiceModel);
}
