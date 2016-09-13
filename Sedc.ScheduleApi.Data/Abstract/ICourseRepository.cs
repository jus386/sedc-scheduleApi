using System;
using Sedc.ScheduleApi.Model.Entities;
using System.Collections.Generic;

namespace Sedc.ScheduleApi.Data.Abstract
{
    public interface ICourseRepository : IEntityBaseRepository<Course>
    {
        IEnumerable<CourseReport> GetCoursesReport();
    }
}
