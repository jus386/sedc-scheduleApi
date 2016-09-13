using Sedc.ScheduleApi.WebApi.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.ViewModels
{
    public class ScheduleViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public DateTime Starting { get; set; }

        public DateTime Ending { get; set; }

        public int DurationHours { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ScheduleViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
