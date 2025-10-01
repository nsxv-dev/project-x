using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project_x.DTOs;
using project_x.Services;

namespace project_x.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = await _authService.RegisterUserAsync(registerUserDto);
            if (user == null)
            {
                return BadRequest("Registration failed");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var token = await _authService.LoginUserAsync(loginUserDto);
            if (token == null)
            {
                return BadRequest("Invalid credentials");
            }

            return Ok(token);
        }

        [HttpGet("auth-test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Authenticated access successful");
        }

        [HttpGet("role-test")]
        [Authorize(Roles = "admin")]
        public IActionResult RoleTest()
        {
            return Ok("Role test access successful");
        }
    }
}

