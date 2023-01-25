namespace MarketPalceManagement.Account.Abstractions;

public interface IAuthenticationCreator
{
    string CreateToken(string userName);
}
