using MarketplaceManagement.DataAccess.Abstractions;
using MarketplaceManagement.Persistence.Context;

namespace MarketplaceManagement.DataAccess.Services;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        ProductRepository = new ProductRepository(_context);
    }
    public IProductRepository ProductRepository { get; }

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
