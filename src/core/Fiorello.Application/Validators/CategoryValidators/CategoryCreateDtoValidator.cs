using Fiorello.Application.DTOs.CategoryDtos;
using FluentValidation;

namespace Fiorello.Application.Validators.CategoryValidator;

public class CategoryCreateDtoValidator:AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        RuleFor(x=> x.Description)
            .MaximumLength(250);
    }
}
