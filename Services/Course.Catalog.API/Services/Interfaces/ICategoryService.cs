using Course.Catalog.API.Models.Dtos;
using Course.Catalog.API.Models.Entities;
using Course.Shared.Models;

namespace Course.Catalog.API.Services.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<List<CategoryDto>>> GetAllCategoriesAsync();
    Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(string id);
    Task<ApiResponse<CategoryDto>> CreateAsync(Category category);
}