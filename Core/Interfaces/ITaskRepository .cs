using Core.Entities;
using Core.Enums;
namespace Core.Interfaces
{
    public interface ITaskRepository : IRepository<Entities.Task>
    {
        Task<IEnumerable<Entities.Task>> GetTasksByStatusAsync(Enums.TaskStatus status);
    }
}
