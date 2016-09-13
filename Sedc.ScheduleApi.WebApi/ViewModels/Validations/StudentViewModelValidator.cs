using FluentValidation;

namespace Sedc.ScheduleApi.WebApi.ViewModels.Validations
{
    public class StudentViewModelValidator : AbstractValidator<StudentViewModel>
    {
        public StudentViewModelValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("First Name cannot be empty");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("Last Name cannot be empty");
        }
    }
}
