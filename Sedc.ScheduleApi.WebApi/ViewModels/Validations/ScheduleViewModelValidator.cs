using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.ScheduleApi.WebApi.ViewModels.Validations
{
    public class ScheduleViewModelValidator : AbstractValidator<ScheduleViewModel>
    {
        public ScheduleViewModelValidator()
        {
            RuleFor(e => e.Ending).GreaterThan(s => s.Starting).WithMessage("Schedule end must be after start");
            RuleFor(s => s.DurationHours).InclusiveBetween(1, 5).WithMessage("Schedule must last between 1 and 5 hours");
        }
    }
}
