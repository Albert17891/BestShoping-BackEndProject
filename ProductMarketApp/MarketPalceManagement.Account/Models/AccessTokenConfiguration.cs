namespace MarketPalceManagement.Account.Models;

public class AccessTokenConfiguration
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public string AccessTokenExpiresMinutes { get; set; }
}
