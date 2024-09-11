using Course.Catalog.API.Models.Dtos;
using Course.Shared.Models;

namespace Course.Catalog.API.Services.Interfaces;

public interface IClassService
{
    Task<ApiResponse<List<ClassDto>>> GetAllClassesAsync();
    Task<ApiResponse<ClassDto>> GetClassByIdAsync(string id);
    Task<ApiResponse<List<ClassDto>>> GetAllClassesByUserIdAsync(string userId);
    Task<ApiResponse<ClassDto>> CreateAsync(CreateClassDto createClassDto);
    Task<ApiResponse<NoContentResponse>> UpdateAsync(UpdateClassDto updateClassDto);
    Task<ApiResponse<NoContentResponse>> DeleteAsync(string id);
}