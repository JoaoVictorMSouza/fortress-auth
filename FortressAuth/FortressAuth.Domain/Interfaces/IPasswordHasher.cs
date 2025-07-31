using FortressAuth.Domain.Entity;

namespace FortressAuth.Domain.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool Verify(User user, string password);
    }
}
