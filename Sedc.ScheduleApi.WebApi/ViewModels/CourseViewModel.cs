using Sedc.ScheduleApi.WebApi.ViewModels.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.ViewModels
{
    public class CourseViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int LengthHours { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CourseViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
