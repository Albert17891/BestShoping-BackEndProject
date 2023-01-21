using MarketplaceManagement.Domain.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceManagement.Persistence.Context;

public class ApplicationContext:IdentityDbContext<AppUser>
{
	public ApplicationContext(DbContextOptions<ApplicationContext> opt):base(opt)
	{

	}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
