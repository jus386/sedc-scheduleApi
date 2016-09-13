using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;

namespace Sedc.ScheduleApi.Data.Repositories
{
    public class StudentRepository : EntityBaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ScheduleContext context) : base(context)
        {
        }
    }
}
