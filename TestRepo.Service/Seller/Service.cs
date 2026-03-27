using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Seller;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateSeller(Request.CreateSellerRequest request)
    {
        var existingUser = _dbContext.Users.Where(x => x.Email == request.Email);
        var isExistedUser = await existingUser.AnyAsync();
        if (isExistedUser)
            throw new Exception("User not found");

        var user = new Repository.Entity.User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "Seller"
        };
        
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();

        var newSeller = new Repository.Entity.Seller()
        {
            TaxCode = request.TaxCode,
            CompanyAddress = request.CompanyAddress,
            CompanyName = request.CompanyName,
            UserId = user.Id,
        };

        _dbContext.Add(newSeller);
        await _dbContext.SaveChangesAsync();
        return "Add Seller Successfully";
    }
}