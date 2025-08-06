using DarkBid.Data;
using DarkBid.Interfaces;
using DarkBid.Services;
using Microsoft.AspNetCore.Mvc;

namespace DarkBid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly ILogger<UserService> _logger;
        public UserController(IUserService userService, ILogger<UserService> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser(string username, string email, string password)
        {
            var result = await _userService.AddUser(username, email, password);

            if (!result) return BadRequest();

            return Ok("User Created");
        }

        [HttpGet ("login")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            var result = await _userService.GetUser(username, password);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, string newUsername, string newEmail, string newPassword)
        {
            var isUpdated = await _userService.UpdateUser(id, newUsername, newEmail, newPassword);

            if (!isUpdated) return NotFound();

            return Ok("User Information Updated");
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);

            if (result)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
