using Application.DTOs;

namespace Application.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task AddUserAsync(UserDto userDto);
    }
}
