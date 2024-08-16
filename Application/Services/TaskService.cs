using Application.DTOs;
using Application.Events;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using AutoMapper;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IEventHandler<TaskAssignedEvent> _taskAssignedEventHandler;
        private readonly IEventHandler<TaskStatusUpdatedEvent> _taskStatusUpdatedEventHandler;

        public TaskService(
            ITaskRepository taskRepository,
            IMapper mapper,
            IEventHandler<TaskAssignedEvent> taskAssignedEventHandler,
            IEventHandler<TaskStatusUpdatedEvent> taskStatusUpdatedEventHandler)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _taskAssignedEventHandler = taskAssignedEventHandler;
            _taskStatusUpdatedEventHandler = taskStatusUpdatedEventHandler;
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
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
            await _taskAssignedEventHandler.Handle(new TaskAssignedEvent(task.UserId, task.Title));
        }

        public async System.Threading.Tasks.Task UpdateTaskStatusAsync(int taskId, Core.Enums.TaskStatus status)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task != null)
            {
                task.Status = status;
                await _taskRepository.UpdateAsync(task);
                await _taskStatusUpdatedEventHandler.Handle(new TaskStatusUpdatedEvent(task.UserId, task.Title, status.ToString()));
            }
        }
    }
}
