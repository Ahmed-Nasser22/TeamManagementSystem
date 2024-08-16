using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _activityService.GetAllActivitiesAsync();
            return Ok(activities);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody] ActivityDto activityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _activityService.AddActivityAsync(activityDto);
            return CreatedAtAction(nameof(GetActivityById), new { id = activityDto.Id }, activityDto);
        }
    }
}
