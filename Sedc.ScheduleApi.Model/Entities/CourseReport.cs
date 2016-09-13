using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.ScheduleApi.Model.Entities
{
    public class CourseReport
    {
        public int CourseId { get; set; }
        public int CourseLengthHours { get; set; }
        public string CourseName { get; set; }
        public int TotalAttendedHours { get; set; }
        public double Attendance { get; set; }
        public int StudentsAttending { get; set; }
    }
}
