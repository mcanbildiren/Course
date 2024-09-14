using Course.Catalog.API.Models.Dtos;
using Course.Catalog.API.Services.Interfaces;
using Course.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace Course.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassController(IClassService classService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAllClasses()
    {
        var response = await classService.GetAllClassesAsync();
        return CreateActionResult(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClassById(string id)
    {
        var response = await classService.GetClassByIdAsync(id);
        return CreateActionResult(response);
    }

    [HttpGet]
    [Route("api/[controller]/GetAllClassesByUserId/{id}")]
    public async Task<IActionResult> GetAllClassesByUserId(string id)
    {
        var response = await classService.GetAllClassesByUserIdAsync(id);
        return CreateActionResult(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClassDto request)
    {
        var response = await classService.CreateAsync(request);
        return CreateActionResult(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateClassDto request)
    {
        var response = await classService.UpdateAsync(request);
        return CreateActionResult(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await classService.DeleteAsync(id);
        return CreateActionResult(response);
    }
}