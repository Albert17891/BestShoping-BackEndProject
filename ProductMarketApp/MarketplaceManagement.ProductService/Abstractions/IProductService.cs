using MarketplaceManagement.ProductService.Models;

namespace MarketplaceManagement.ProductService.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(ProductServcieModel productServcieModel,CancellationToken cancellationToken);
}
