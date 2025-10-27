using FluentValidation;
using LearnEFCore.Features.Student.DTOs;

namespace LearnEFCore.Features.Student.Validators
{
    public class UpdateStudentDtoValidator : AbstractValidator<UpdateStudentDto>
    {
        public UpdateStudentDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).When(x => x.Name != null);
            RuleFor(x => x.Email).EmailAddress().When(x => x.Email != null);
            RuleFor(x => x.Course).MaximumLength(50).When(x => x.Course != null);
        }
    }
}