using System;
using System.Linq;
using System.Collections.Generic;
using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;

namespace Sedc.ScheduleApi.Data.Repositories
{
    public class CourseRepository : EntityBaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ScheduleContext context) : base(context)
        {
        }

        public IEnumerable<CourseReport> GetCoursesReport()
        {
            var studentsCount = _context.Students.Count();

            var q = from c in _context.Courses
                    join sch in _context.Schedules on c.Id equals sch.CourseId into schedules
                    let total = schedules.Sum(x => x.Attendances.Sum(y => x.DurationHours))
                    let distinctStudents = schedules.SelectMany(x=>x.Attendances.Select(y=>y.StudentId)).Distinct().Count()
                    select new CourseReport
                    {
                        CourseId = c.Id,
                        CourseLengthHours = c.LengthHours,
                        CourseName = c.Name,
                        TotalAttendedHours = total,
                        StudentsAttending = distinctStudents
                    };
            var coursesList = q
                .ToList();

            coursesList.ForEach(x => x.Attendance = Math.Round(100 * ((double)x.TotalAttendedHours / ((double)x.CourseLengthHours * studentsCount)), 0));
            return coursesList;
        }
    }
}
