using FluentValidation;
using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Validators
{
    public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.EnrollmentDate).NotEmpty();
            RuleFor(x => x.Course).NotEmpty().MaximumLength(50);
        }
    }
}