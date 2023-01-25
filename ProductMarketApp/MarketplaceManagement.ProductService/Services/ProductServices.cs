using Mapster;
using MarketplaceManagement.DataAccess.Abstractions;
using MarketplaceManagement.Domain.ProductModel;
using MarketplaceManagement.ProductService.Abstractions;
using MarketplaceManagement.ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceManagement.ProductService.Services;

public class ProductServices : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public async Task<int> AddProductAsync(ProductServcieModel productServcieModel, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var product = productServcieModel.Adapt<Product>();

        await _unitOfWork.ProductRepository.AddProductAsync(product);

        await _unitOfWork.SaveChangeAsync();

        return product.Id;
    }

    public async Task<IList<ProductServcieModel>> GetProductsAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var products = await _unitOfWork.ProductRepository.Table.ToListAsync();

        return products.Adapt<IList<ProductServcieModel>>();
    }
}
