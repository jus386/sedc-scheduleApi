using System.Collections.Generic;

namespace Sedc.ScheduleApi.Model.Entities
{
    public class Student : IEntityBase
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Attendance> Attendances { get; set; }

        public Student()
        {
            Attendances = new List<Attendance>();
        }
    }
}
