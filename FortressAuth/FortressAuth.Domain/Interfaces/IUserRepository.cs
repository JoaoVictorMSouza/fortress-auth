using FortressAuth.Domain.Entity;

namespace FortressAuth.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
