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
            // Basic validation
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            // Check if email and password are provided
            if (string.IsNullOrEmpty(loginUserDto.Email) || string.IsNullOrEmpty(loginUserDto.Password))
            {
                return BadRequest("E-mail and password are required");
            }
            try
            {
                // Validate user credentials
                var user = await _authService.ValidateUserCredentialsAsync(loginUserDto.Email, loginUserDto.Password);
                if (user == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                // Generate JWT token
                var token = await _authService.GenerateJwtTokenAsync(user);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

