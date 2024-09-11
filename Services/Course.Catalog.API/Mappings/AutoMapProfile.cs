using AutoMapper;
using Course.Catalog.API.Models.Entities;
using Course.Catalog.API.Models.Dtos;

namespace Course.Catalog.API.Mappings;

public class AutoMapProfile : Profile
{
    public AutoMapProfile()
    {
        CreateMap<Class, ClassDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Feature, FeatureDto>().ReverseMap();
        CreateMap<Class, CreateClassDto>().ReverseMap();
        CreateMap<Class, UpdateClassDto>().ReverseMap();
    }
}