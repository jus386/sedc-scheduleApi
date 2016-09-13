using System.Collections.Generic;

namespace Sedc.ScheduleApi.Model.Entities
{
    public class Course : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int LengthHours { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public Course()
        {
            Schedules = new List<Schedule>();
        }
    }
}
