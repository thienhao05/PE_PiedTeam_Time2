using Microsoft.AspNetCore.Mvc;
using TetPee.Repository.Entity;
using TetPee.Service.User;

namespace TestRepo.Api.Controller;

[ApiController] //chỗ này nè
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IService _userService;
    public UserController(IService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateUser([FromBody] Request.UserRequest request)
    {
        var user = await _userService.CreateUser(request);
        return Ok(user);
    }
}