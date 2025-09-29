using Microsoft.EntityFrameworkCore;
using project_x.Data;
using project_x.Models;
namespace project_x.Services

{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task RegisterUserAsync(string username, string password, string email)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username))
            {
                throw new Exception("Username already exists");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Email = email,
                Username = username,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
