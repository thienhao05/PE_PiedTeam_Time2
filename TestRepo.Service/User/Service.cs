using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.User;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<string> CreateUser(Request.UserRequest request)
    {
        var existingEmail = _dbContext.Users.Where(x => x.Email == request.Email);
        var isExistedEmail = await existingEmail.AnyAsync();
        if (isExistedEmail)
            throw new Exception("Email has been user");
        var newUser = new Repository.Entity.User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "User"
        };
        _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();
        return "Add User successfully";
    }
}