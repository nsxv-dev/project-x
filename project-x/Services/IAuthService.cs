using project_x.DTOs;
using project_x.Models;

namespace project_x.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterUserAsync(AuthUserDto dto);
        Task<string?> LoginUserAsync(AuthUserDto dto);
    }
}
