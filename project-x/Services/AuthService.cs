using project_x.Data;
using project_x.Models;
using BCrypt.Net;

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
                throw new Exception("Username arleady exists");
            }

            var passwordHash = BCrypt.HashPassword(password);


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
