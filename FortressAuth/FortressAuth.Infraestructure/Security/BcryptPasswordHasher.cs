using FortressAuth.Domain.Entity;
using FortressAuth.Domain.Interfaces;

namespace FortressAuth.Infraestructure.Security
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public bool Verify(User user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user?.PasswordHash);
        }
    }
}
