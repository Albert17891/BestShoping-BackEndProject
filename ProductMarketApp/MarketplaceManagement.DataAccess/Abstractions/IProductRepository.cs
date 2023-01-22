using MarketplaceManagement.Domain.ProductModel;

namespace MarketplaceManagement.DataAccess.Abstractions;

public interface IProductRepository
{
    IQueryable<Product> Table { get; }

    Task AddAsync(Product product);
    void Update(Product product);
}
