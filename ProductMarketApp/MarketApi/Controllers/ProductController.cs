using Mapster;
using MarketApi.Model.Request.Product;
using MarketApi.Model.Response.Product;
using MarketplaceManagement.ProductService.Abstractions;
using MarketplaceManagement.ProductService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken = default)
    {
        var products = await _productService.GetProductsAsync(cancellationToken);

        return Ok(products.Adapt<IList<ProductResponse>>());
    }

    [Route("product-add")]
    [HttpPost]
    public async Task<IActionResult> ProductAdd(ProductRequest productRequest, CancellationToken cancellationToken = default)
    {
        if (productRequest is null)
        {
            return BadRequest();
        }

        var result = await _productService.AddProductAsync(productRequest.Adapt<ProductServcieModel>(), cancellationToken);

        return Ok(result);
    }
}
