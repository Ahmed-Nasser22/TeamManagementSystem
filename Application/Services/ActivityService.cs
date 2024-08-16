using Application.DTOs;
using Core.Entities;
using Core.Interfaces;
using AutoMapper;

namespace Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<ActivityDto> GetActivityByIdAsync(Guid id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);
            return _mapper.Map<ActivityDto>(activity);
        }

        public async Task<IEnumerable<ActivityDto>> GetAllActivitiesAsync()
        {
            var activities = await _activityRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ActivityDto>>(activities);
        }

        public async System.Threading.Tasks.Task AddActivityAsync(ActivityDto activityDto)
        {
            var activity = _mapper.Map<Activity>(activityDto);
            await _activityRepository.AddAsync(activity);
        }
    }
}
