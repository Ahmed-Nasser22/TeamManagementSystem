using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
