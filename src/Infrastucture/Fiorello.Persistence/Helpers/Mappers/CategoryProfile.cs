using AutoMapper;
using Fiorello.Application.DTOs.CategoryDtos;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistence.Helpers.Mappers;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
    }
}
