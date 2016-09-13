using FluentValidation;

namespace Sedc.ScheduleApi.WebApi.ViewModels.Validations
{
    public class MultiAttendanceViewModelValidator : AbstractValidator<MultiAttendanceViewModel>
    {
        public MultiAttendanceViewModelValidator()
        {
            RuleFor(c => c.ScheduleId).GreaterThan(0).WithMessage("ScheduleId must be greater than 0");
            RuleFor(c => c.StudentsIds).NotEmpty().WithMessage("StudentsIds must not be empty");
        }
    }
}
