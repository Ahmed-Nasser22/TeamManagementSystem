using Application.DTOs;
using Core.Enums;

namespace Application.Services
{
    public interface ITaskService
    {
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(Core.Enums.TaskStatus status);
        Task AddTaskAsync(TaskDto taskDto);
        Task UpdateTaskStatusAsync(int taskId, Core.Enums.TaskStatus status);
    }
}
