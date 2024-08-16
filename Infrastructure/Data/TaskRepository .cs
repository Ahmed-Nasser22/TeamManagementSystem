using Core.Enums;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TaskRepository : Repository<Core.Entities.Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Core.Entities.Task>> GetTasksByStatusAsync(Core.Enums.TaskStatus status)
        {
            return await _dbSet.Where(t => t.Status == status).ToListAsync();
        }
    }
}
