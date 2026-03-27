using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Seller;

namespace TestRepo.Api.Controller;

[ApiController] //chỗ này nè
[Route("[controller]")]
public class SellerController : ControllerBase
{
    private readonly IService _sellerService;

    public SellerController(IService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateSeller(Request.CreateSellerRequest request)
    {
        var seller = await _sellerService.CreateSeller(request);
        return Ok(seller);
    }
}