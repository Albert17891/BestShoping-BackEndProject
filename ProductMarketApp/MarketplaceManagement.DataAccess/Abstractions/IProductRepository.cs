using MarketplaceManagement.Domain.ProductModel;

namespace MarketplaceManagement.DataAccess.Abstractions;

public interface IProductRepository
{
    IQueryable<Product> Table { get; }

    Task AddProductAsync(Product product);
    void UpdateProduct(Product product);
}
