using Microsoft.EntityFrameworkCore;
using Sedc.ScheduleApi.Model.Entities;

namespace Sedc.ScheduleApi.Data
{
    public class ScheduleContext : DbContext
    {
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Student> Students { get; set; }

        public ScheduleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasKey(k => k.Id);
            modelBuilder.Entity<Course>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Schedule>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Student>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Course>()
                .HasMany(m => m.Schedules)
                .WithOne(o => o.Course)
                .HasForeignKey(f => f.CourseId);
            modelBuilder.Entity<Schedule>()
                .HasMany(m => m.Attendances)
                .WithOne(o => o.Schedule)
                .HasForeignKey(f => f.ScheduleId);
            modelBuilder.Entity<Student>()
                .HasMany(m => m.Attendances)
                .WithOne(o => o.Student)
                .HasForeignKey(f => f.StudentId);
        }
    }
}
