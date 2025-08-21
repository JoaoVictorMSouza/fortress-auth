using FortressAuth.Domain.Entity;

namespace FortressAuth.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user, DateTime expiresAtUtc);
        string GenerateRefreshToken();
        public DateTime GetExpirationAcessToken();
        public DateTime GetExpirationRefreshToken();
    }
}
