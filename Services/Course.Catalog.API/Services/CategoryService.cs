using AutoMapper;
using Course.Catalog.API.Models.Dtos;
using Course.Catalog.API.Models.Entities;
using Course.Catalog.API.Services.Interfaces;
using Course.Catalog.API.Settings;
using Course.Shared.Models;
using MongoDB.Driver;

namespace Course.Catalog.API.Services;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<CategoryDto>>> GetAllCategoriesAsync()
    {
        var categories = await _categoryCollection.Find(c => true).ToListAsync();
        var response = new ApiResponse<List<CategoryDto>>().Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        return response;
    }

    public async Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(string id)
    {
        var category = await _categoryCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        
        return category == null ? new ApiResponse<CategoryDto>().Fail("Category not found", 404) : new ApiResponse<CategoryDto>().Success(_mapper.Map<CategoryDto>(category), 200);
    }

    public async Task<ApiResponse<CategoryDto>> CreateAsync(Category category)
    {
        await _categoryCollection.InsertOneAsync(category);
        var response = new ApiResponse<CategoryDto>().Success(_mapper.Map<CategoryDto>(category), 200);
        return response;
    }
}