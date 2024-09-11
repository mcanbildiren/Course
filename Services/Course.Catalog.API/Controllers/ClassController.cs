using Course.Catalog.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Course.Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassController(IClassService classService) : ControllerBase
{
    
}