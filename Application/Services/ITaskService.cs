using Application.DTOs;

namespace Application.Services
{
    public interface IActivityService
    {
        Task<ActivityDto> GetActivityByIdAsync(Guid id);
        Task<IEnumerable<ActivityDto>> GetAllActivitiesAsync();
        Task AddActivityAsync(ActivityDto activityDto);
    }
}
