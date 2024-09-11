using System.Text.Json.Serialization;

namespace Course.Shared.Models;

public class ApiResponse<T>
{
    public T Data { get; set; }
    [JsonIgnore] public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; }

    public  ApiResponse<T> Success(T data, int statusCode)
    {
        return new ApiResponse<T> { Data = data, StatusCode = statusCode, IsSuccess = true };
    }

    public ApiResponse<T> Success(int statusCode)
    {
        return new ApiResponse<T> { Data = default, StatusCode = statusCode, IsSuccess = true };
    }

    public ApiResponse<T> Fail(List<string> errors, int statusCode)
    {
        return new ApiResponse<T> {Errors = errors, StatusCode = statusCode, IsSuccess = false };
    }
    
    public ApiResponse<T> Fail(string error, int statusCode)
    {
        return new ApiResponse<T> {Errors = [error], StatusCode = statusCode, IsSuccess = false };
    }
}