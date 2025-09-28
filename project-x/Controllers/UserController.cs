using Microsoft.AspNetCore.Mvc;
using project_x.Data;
using project_x.DTOs;
using project_x.Models;

namespace project_x.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new { message = $"User {user.Username} registered successfully." });
        }
    }
}
