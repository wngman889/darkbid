using DarkBid.Data;
using DarkBid.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DarkBid.Services
{
    public class UserService : IUserService
    {
        private readonly DarkBidContext _dbContext;
        //private readonly UserManager<User> _userManager;

        private readonly ILogger<UserService> _logger;

        public UserService(DarkBidContext dbContext, ILogger<UserService> logger)//UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _logger = logger;
            //_userManager = userManager;
        }

        public async Task<bool> AddUser(string username, string email, string password)
        {
            try
            {
                var newUser = new User
                {
                    Username = username,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                };

                _dbContext.Users.Add(newUser);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<User?> GetUser(string username, string password)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

                if (user is null)
                {
                    return null;
                }

                var correctPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (!correctPassword)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<User>?> GetAllUsers()
        {
            try
            {
                var users = await _dbContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateUser(int id, string newUsername, string newEmail, string newPassword)
        {
            try
            {
                var existingUser = await _dbContext.Users.FindAsync(id);

                if (existingUser == null)
                    return false;

                existingUser.Username = newUsername;
                existingUser.Password = newPassword;
                existingUser.Email = newEmail;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _dbContext.Users.FindAsync(id);

                if (userToDelete == null)
                    return false;

                _dbContext.Users.Remove(userToDelete);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
