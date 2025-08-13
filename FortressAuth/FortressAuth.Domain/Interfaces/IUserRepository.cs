using FortressAuth.Domain.Entity;
using FortressAuth.Domain.ValueObjects.User;

namespace FortressAuth.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync(UserFilter userFilter);
    }
}
