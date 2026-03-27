using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TetPee.Repository;
using TetPee.Service.JwtService;

namespace TetPee.Service.Identity;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtService.IService _jwtService;
    private readonly JwtOptions _jwtOption = new();

    public Service(IConfiguration configuration, AppDbContext dbContext, JwtService.IService jwtService)
    {
        _dbContext = dbContext;
        _jwtService = jwtService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOption);
    }

    public async Task<Response.IdentityResponse> Login(Request.IdentityRequest request)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
        if (user == null)
            throw new Exception("User not found");
        if (user.Password != request.Password)
            throw new Exception("Password invalid");

        var claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };
        
        var token = _jwtService.GenerateAccessToken(claims);
        var result = new Response.IdentityResponse
        {
            AccessToken = token,
        };
        return result;
    }
}