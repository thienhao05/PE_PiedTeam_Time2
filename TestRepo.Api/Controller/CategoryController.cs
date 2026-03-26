using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Category;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IService _categoryService;

    public CategoryController(IService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateCategory(Request.CreateCategoryRequest request)
    {
        var result = await _categoryService.CreateCategory(request);
        return Ok(result);
    }
}