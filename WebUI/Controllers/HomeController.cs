using Microsoft.AspNetCore.Mvc;
using Application.Services; // Ensure to include this
using Application.DTOs;
using Core.Enums;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;

        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetTasksByStatusAsync(Core.Enums.TaskStatus.Assigned); 
            return View(tasks);
        }
    }
}
