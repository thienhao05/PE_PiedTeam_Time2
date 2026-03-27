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

    public async Task<Base.Response.PageResult<Response.UserResponse>> GetUsers(Request.GetAllUserRequest request)
    {
        var query =  _dbContext.Users.Where(u => true);
        if (request.SearchTerm != null)
        {
            query = _dbContext.Users.Where(u => u.Email == request.SearchTerm);
        }
        query  = query.OrderBy(u => u.Email);
        query = query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize);
        var selectedQuery = query.Select(u => new Response.UserResponse()
        {
            Email = u.Email,
            Password = u.Password,
            Role = u.Role
        });
        var pageResult = await selectedQuery.ToListAsync();
        var totalItems =  pageResult.Count;
        var result = new Base.Response.PageResult<Response.UserResponse>()
        {
            Items = pageResult,
            TotalItems = totalItems,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize
        };
        return result;
        
    }
    
}