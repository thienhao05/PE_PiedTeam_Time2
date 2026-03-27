using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Identity;

namespace TestRepo.Api.Controller;

[ApiController] //chỗ này nè
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IService _identityService;
    public IdentityController(IService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("")]
    public async Task<IActionResult> Login(Request.IdentityRequest request)
    {
        var  result = await _identityService.Login(request);
        return Ok(result);
    }
}