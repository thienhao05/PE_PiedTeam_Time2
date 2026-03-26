using System.Xml.Schema;
using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<string> CreateCategory(Request.CreateCategoryRequest request)
    {
        var existingCategory = _dbContext.Categories.Where(x => x.Name == request.Name);
        var isExistCategory = await existingCategory.AnyAsync();
        if (isExistCategory)
        {
            throw new Exception("Category already exists");
        }

        var newCategory = new Repository.Entity.Category()
        {
            Name = request.Name,
            ParentId = request.ParentId
        };
        _dbContext.Add(newCategory);
        await _dbContext.SaveChangesAsync();
        return "Add Category Successfully";
    }

}