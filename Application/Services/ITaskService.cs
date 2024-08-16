using Application.DTOs;

namespace Application.Services
{
    public interface IActivityService
    {
        Task<ActivityDto> GetActivityByIdAsync(int id);
        Task<IEnumerable<ActivityDto>> GetAllActivitiesAsync();
        Task AddActivityAsync(ActivityDto activityDto);
    }
}
