using FortressAuth.Domain.Entity;
using System.Security.Claims;

namespace FortressAuth.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user, DateTime expiresAtUtc);
        string GenerateRefreshToken();
        public DateTime GetExpirationAcessToken();
        public DateTime GetExpirationRefreshToken();
        ClaimsPrincipal GetPayloadClaimsPrincipalFromExpiredToken(string token);
    }
}
