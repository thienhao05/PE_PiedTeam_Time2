using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Product;

namespace TestRepo.Api.Controller;


[ApiController] //chỗ này nè
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IService _productService;
    public ProductController(IService productService)
    {
        _productService = productService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateProduct(Request.ProductRequest request)
    {
        var products = await _productService.CreateProduct(request);
        return Ok(products);
    }
}