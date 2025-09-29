using Microsoft.AspNetCore.Mvc;
using project_x.DTOs;
using project_x.Services;

namespace project_x.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {

            if (string.IsNullOrEmpty(registerUserDto.Username) || string.IsNullOrEmpty(registerUserDto.Password))
            {
                return BadRequest("Username and password are required");
            }

            try
            {
                await _authService.RegisterUserAsync(registerUserDto.Username, registerUserDto.Password, registerUserDto.Email);
                return Ok($"User {registerUserDto.Username} has been registered successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

