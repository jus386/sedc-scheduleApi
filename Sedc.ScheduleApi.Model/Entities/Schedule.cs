using System;
using System.Collections.Generic;

namespace Sedc.ScheduleApi.Model.Entities
{
    public class Schedule : IEntityBase
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public DateTime Starting { get; set; }

        public DateTime Ending { get; set; }

        public int DurationHours { get; set; }

        public Course Course { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public Schedule()
        {
            Attendances = new List<Attendance>();
        }
    }
}
