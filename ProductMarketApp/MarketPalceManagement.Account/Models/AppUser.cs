using Microsoft.AspNet.Identity.EntityFramework;

namespace MarketPalceManagement.Account.Models;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
