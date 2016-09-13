using Sedc.ScheduleApi.Model.Entities;
using System;
using System.Linq;

namespace Sedc.ScheduleApi.Data
{
    public class ScheduleDbInitializer
    {
        private static ScheduleContext context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            context = (ScheduleContext)serviceProvider.GetService(typeof(ScheduleContext));

            InitializeDb();
        }

        private static void InitializeDb()
        {
            if (!context.Students.Any())
            {
                var student1 = new Student
                {
                    FirstName = "Aleksandar",
                    LastName = "Bozinovski"
                };
                var student2 = new Student
                {
                    FirstName = "Test 1",
                    LastName = "Test 1", 
                };
                var student3 = new Student
                {
                    FirstName = "Test 2",
                    LastName = "Test 2",
                };
                var student4 = new Student
                {
                    FirstName = "Test 3",
                    LastName = "Test 3",
                };
                context.Students.Add(student1);
                context.Students.Add(student2);
                context.Students.Add(student3);
                context.Students.Add(student4);

                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                var c1 = new Course
                {
                    Name = "Web Api",
                    Description = "Asp.NET Web Api",
                    LengthHours = 20
                };
                var c2 = new Course
                {
                    Name = "JavaScript & jQuery ",
                    Description = "JavaScript & jQuery Development",
                    LengthHours = 28
                };
                var c3 = new Course
                {
                    Name = "Angular",
                    Description = "Angular 2",
                    LengthHours = 32
                };
                var c4 = new Course
                {
                    Name = "Basic Web Development",
                    Description = "Basic Web Development (HTML5/CSS3)",
                    LengthHours = 16
                };
                var c5 = new Course
                {
                    Name = "Advanced JavaScript",
                    Description = "Advanced JavaScript Programming",
                    LengthHours = 40
                };
                context.Courses.Add(c1);
                context.Courses.Add(c2);
                context.Courses.Add(c3);
                context.Courses.Add(c4);
                context.Courses.Add(c5);

                context.SaveChanges();
            }

            if (!context.Schedules.Any())
            {
                var courses = context.Courses.ToList();
                foreach (var c in courses)
                {
                    var cHours = c.LengthHours;
                    var startDate = DateTime.Today.AddHours(17); // start at 17:00
                    while(cHours > 0)
                    {
                        context.Schedules.Add(new Schedule
                        {
                            Course = c,
                            Starting = startDate,
                            Ending = startDate.AddHours(4),
                            DurationHours = 4
                        });
                        cHours = cHours - 4;
                    }
                }
                context.SaveChanges();
            }

            if (!context.Attendances.Any())
            {
                // Attendances will be created later on
            }
        }
    }
}
