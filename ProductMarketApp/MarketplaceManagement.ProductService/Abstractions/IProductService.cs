using MarketplaceManagement.ProductService.Models;

namespace MarketplaceManagement.ProductService.Abstractions;

public interface IProductService
{
    Task<IList<ProductServcieModel>> GetProductsAsync(CancellationToken cancellationToken);
    Task<int> AddProductAsync(ProductServcieModel productServcieModel, CancellationToken cancellationToken);
}
