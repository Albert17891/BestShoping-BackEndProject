using MarketplaceManagement.Domain;
using MarketplaceManagement.Domain.Account;
using MarketplaceManagement.Domain.ProductModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceManagement.Persistence.Context;

public class ApplicationContext : IdentityDbContext<AppUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<UserProduct> UserProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UserProduct>()
            .HasKey(x => new { x.UserId, x.ProductId });

        builder.Entity<UserProduct>()
            .HasOne<Product>(x => x.Product)
            .WithMany(x => x.UsersProducts)
            .HasForeignKey(x=>x.ProductId);

        builder.Entity<UserProduct>()
            .HasOne<AppUser>(x => x.AppUser)
            .WithMany(x => x.UserProducts)
            .HasForeignKey(x=>x.UserId);
            

        base.OnModelCreating(builder);
    }
}
