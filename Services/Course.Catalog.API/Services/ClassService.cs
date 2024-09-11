using AutoMapper;
using Course.Catalog.API.Models.Dtos;
using Course.Catalog.API.Models.Entities;
using Course.Catalog.API.Services.Interfaces;
using Course.Catalog.API.Settings;
using Course.Shared.Models;
using MongoDB.Driver;

namespace Course.Catalog.API.Services;

public class ClassService : IClassService
{
    private readonly IMongoCollection<Class> _classCollection;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public ClassService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _classCollection = database.GetCollection<Class>(databaseSettings.ClassCollectionName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<ApiResponse<List<ClassDto>>> GetAllClassesAsync()
    {
        var classes = await _classCollection.Find(c => true).ToListAsync();
        if (classes.Count != 0)
        {
            foreach (var item in classes)
            {
                item.Category = await _categoryCollection.Find(c => c.Id == item.CategoryId).FirstOrDefaultAsync();
            }
        }
        else
        {
            classes = [];
        }

        var response = new ApiResponse<List<ClassDto>>().Success(_mapper.Map<List<ClassDto>>(classes), 200);
        return response;
    }

    public async Task<ApiResponse<ClassDto>> GetClassByIdAsync(string id)
    {
        var classes = await _classCollection.Find(x => true).FirstOrDefaultAsync();
        if (classes == null)
        {
            return new ApiResponse<ClassDto>().Fail("Class not found", 404);
        }

        classes.Category = await _categoryCollection.Find(c => c.Id == classes.CategoryId).FirstOrDefaultAsync();
        return new ApiResponse<ClassDto>().Success(_mapper.Map<ClassDto>(classes), 200);
    }

    public async Task<ApiResponse<List<ClassDto>>> GetAllClassesByUserIdAsync(string userId)
    {
        var classes = await _classCollection.Find(x => x.UserId == userId).ToListAsync();

        if (classes.Count != 0)
        {
            foreach (var item in classes)
            {
                item.Category = await _categoryCollection.Find(c => c.Id == item.CategoryId).FirstOrDefaultAsync();
            }
        }
        else
        {
            classes = [];
        }

        var response = new ApiResponse<List<ClassDto>>().Success(_mapper.Map<List<ClassDto>>(classes), 200);
        return response;
    }

    public async Task<ApiResponse<ClassDto>> CreateAsync(CreateClassDto createClassDto)
    {
        var classes = _mapper.Map<Class>(createClassDto);
        classes.CreateDate = DateTime.Now;
        await _classCollection.InsertOneAsync(classes);

        return new ApiResponse<ClassDto>().Success(_mapper.Map<ClassDto>(classes), 200);
    }

    public async Task<ApiResponse<NoContentResponse>> UpdateAsync(UpdateClassDto updateClassDto)
    {
        var updateClass = _mapper.Map<Class>(updateClassDto);
        var result = await _classCollection.FindOneAndReplaceAsync(x => x.Id == updateClassDto.Id, updateClass);

        return result == null
            ? new ApiResponse<NoContentResponse>().Fail("Class not found", 404)
            : new ApiResponse<NoContentResponse>().Success(204);
    }

    public async Task<ApiResponse<NoContentResponse>> DeleteAsync(string id)
    {
        var result = await _classCollection.DeleteOneAsync(x => x.Id == id);

        return result.DeletedCount > 0
            ? new ApiResponse<NoContentResponse>().Success(204)
            : new ApiResponse<NoContentResponse>().Fail("Class not found", 404);
    }
}