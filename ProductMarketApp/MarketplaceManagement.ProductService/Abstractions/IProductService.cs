using MarketplaceManagement.ProductService.Models;

namespace MarketplaceManagement.ProductService.Abstractions;

public interface IProductService
{
    Task AddProductAsync(ProductServcieModel productServcieModel,CancellationToken cancellationToken);
}
