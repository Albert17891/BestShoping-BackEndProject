namespace MarketplaceManagement.DataAccess.Abstractions;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    Task<int> SaveChangeAsync();
}
