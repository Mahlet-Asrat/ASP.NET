using FluentValidation;
using SchoolApi.Dtos;

namespace SchoolApi.Validators
{
    public class CreateSchoolDtoValidator : AbstractValidator<CreateSchoolDto>
    {
        public CreateSchoolDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Director).MaximumLength(100);
            RuleFor(x => x.Teachers).NotEmpty();
            RuleFor(x => x.Students).NotEmpty();
        }
    }
}
