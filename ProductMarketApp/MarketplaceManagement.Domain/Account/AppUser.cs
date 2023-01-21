
using Microsoft.AspNetCore.Identity;

namespace MarketplaceManagement.Domain.Account;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
