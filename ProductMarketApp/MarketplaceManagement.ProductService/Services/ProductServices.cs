using MarketplaceManagement.ProductService.Abstractions;
using MarketplaceManagement.ProductService.Models;

namespace MarketplaceManagement.ProductService.Services;

public class ProductServices : IProductService
{
    public Task AddProductAsync(ProductServcieModel productServcieModel, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
    }
}
