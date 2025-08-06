using DarkBid.Data;

namespace DarkBid.Interfaces
{
    public interface IUserService
    {
        public Task<bool> AddUser(string username, string email, string password);

        public Task<User?> GetUser(string username, string password);

        public Task<IEnumerable<User>?> GetAllUsers();

        public Task<bool> UpdateUser(int id, string newUsername, string newEmail, string newPassword);

        Task<bool> DeleteUser(int id);
    }
}
