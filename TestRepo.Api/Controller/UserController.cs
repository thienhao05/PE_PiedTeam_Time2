using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestRepo.Api.Extensions;
using TetPee.Repository.Entity;
using TetPee.Service.User;

namespace TestRepo.Api.Controller;

[ApiController]
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
    
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    [HttpGet("")]
    public async Task<IActionResult> GetUsers([FromQuery] Request.GetAllUserRequest request)
    {
        var user = await _userService.GetUsers(request);
        return Ok(user);
    }
}