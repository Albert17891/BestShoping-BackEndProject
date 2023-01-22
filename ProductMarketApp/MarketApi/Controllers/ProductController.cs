using Mapster;
using MarketApi.Model.Request.Product;
using MarketplaceManagement.ProductService.Abstractions;
using MarketplaceManagement.ProductService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers;
[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
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
