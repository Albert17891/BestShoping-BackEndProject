using MarketplaceManagement.Domain.Account;
using MarketplaceManagement.Domain.ProductModel;

namespace MarketplaceManagement.Domain;

public class UserProduct
{
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public AppUser AppUser { get; set; }
}
