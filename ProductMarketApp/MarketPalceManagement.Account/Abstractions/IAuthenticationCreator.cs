namespace MarketPalceManagement.Account.Abstractions;

public interface IAuthenticationCreator
{
    Task<string> CreateToken(string userName);
}
