using FluentValidation;
using SchoolApi.SchoolProject.Dtos;

namespace SchoolApi.Validators
{
    public class UpdateSchoolDtoValidator : AbstractValidator<UpdateSchoolDto>
    {
        public UpdateSchoolDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Director).MaximumLength(100);
        }
    }
}
