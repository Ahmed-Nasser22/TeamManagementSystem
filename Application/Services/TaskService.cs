using Application.DTOs;
using AutoMapper;
using Core.Interfaces;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> GetTaskByIdAsync(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<IEnumerable<TaskDto>> GetTasksByStatusAsync(Core.Enums.TaskStatus status)
        {
            var tasks = await _taskRepository.GetTasksByStatusAsync(status);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async System.Threading.Tasks.Task AddTaskAsync(TaskDto taskDto)
        {
            var task = _mapper.Map<Core.Entities.Task>(taskDto);
            await _taskRepository.AddAsync(task);
        }

        public async System.Threading.Tasks.Task UpdateTaskStatusAsync(Guid taskId, Core.Enums.TaskStatus status)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task != null)
            {
                task.Status = status;
                await _taskRepository.UpdateAsync(task);
            }
        }
    }
}
