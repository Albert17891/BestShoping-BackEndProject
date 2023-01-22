using MarketplaceManagement.Domain.Account;

namespace MarketplaceManagement.ProductService.Models;

public class ProductServcieModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool IsActive { get; set; }
}
