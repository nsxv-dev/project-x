using project_x.DTOs;
using project_x.Models;

namespace project_x.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterUserAsync(RegisterUserDto dto);
        Task<string?> LoginUserAsync(LoginUserDto dto);
    }
}
