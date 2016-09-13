using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;

namespace Sedc.ScheduleApi.Data.Repositories
{
    public class AttandanceRepository : EntityBaseRepository<Attendance>, IAttandanceRepository
    {
        public AttandanceRepository(ScheduleContext context) : base(context)
        {
        }
    }
}
