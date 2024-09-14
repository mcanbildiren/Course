using Course.Catalog.API.Models.Dtos;
using Course.Catalog.API.Services.Interfaces;
using Course.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace Course.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var response = await categoryService.GetAllCategoriesAsync();
        return CreateActionResult(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var response = await categoryService.GetCategoryByIdAsync(id);
        return CreateActionResult(response);
    } 
    
    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto request)
    {
        var response = await categoryService.CreateAsync(request);
        return CreateActionResult(response);
    }
}