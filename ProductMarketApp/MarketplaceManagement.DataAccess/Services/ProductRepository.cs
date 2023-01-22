using MarketplaceManagement.DataAccess.Abstractions;
using MarketplaceManagement.Domain.ProductModel;
using MarketplaceManagement.Persistence.Context;

namespace MarketplaceManagement.DataAccess.Services;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
	private readonly ApplicationContext _context;

	public ProductRepository(ApplicationContext context) : base(context)
	{
		_context = context;
	}

	public async Task AddAsync(Product product)
	{
		await AddAsync(product);
	}
}
