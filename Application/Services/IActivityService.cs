using Application.DTOs;
using Core.Enums;

namespace Application.Services
{
    public interface ITaskService
    {
        Task<TaskDto> GetTaskByIdAsync(Guid id);
        Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(Core.Enums.TaskStatus status);
        Task AddTaskAsync(TaskDto taskDto);
        Task UpdateTaskStatusAsync(Guid taskId, Core.Enums.TaskStatus status);
    }
}
