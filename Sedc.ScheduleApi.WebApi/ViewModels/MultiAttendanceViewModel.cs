using Sedc.ScheduleApi.WebApi.ViewModels.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.ViewModels
{
    public class MultiAttendanceViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public int[] StudentsIds { get; set; }

        public int ScheduleId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new MultiAttendanceViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
