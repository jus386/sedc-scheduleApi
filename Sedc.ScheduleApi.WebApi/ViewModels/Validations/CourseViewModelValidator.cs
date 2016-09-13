using FluentValidation;

namespace Sedc.ScheduleApi.WebApi.ViewModels.Validations
{
    public class CourseViewModelValidator : AbstractValidator<CourseViewModel>
    {
        public CourseViewModelValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(c => c.LengthHours).InclusiveBetween(5, 50).WithMessage("Course must have between 5 and 50 hours");
        }
    }
}
