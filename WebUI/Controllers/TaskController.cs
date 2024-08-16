using Application.DTOs;
using Application.Services;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetTasksByStatus(Core.Enums.TaskStatus status)
        {
            var tasks = await _taskService.GetTasksByStatusAsync(status);
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _taskService.AddTaskAsync(taskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = taskDto.Id }, taskDto);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateTaskStatus(int id, [FromBody] Core.Enums.TaskStatus status)
        {
            await _taskService.UpdateTaskStatusAsync(id, status);
            return NoContent();
        }
    }
}
