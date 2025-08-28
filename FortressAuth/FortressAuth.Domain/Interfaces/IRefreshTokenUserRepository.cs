using FortressAuth.Domain.Entities;

namespace FortressAuth.Domain.Interfaces
{
    public interface IRefreshTokenUserRepository
    {
        Task<RefreshTokenUser?> GetRefreshTokenUserByTokenAsync(string token);
        Task AddRefreshTokenUserAsync(RefreshTokenUser refreshToken);
        Task SetRevokedRefreshTokenUser(RefreshTokenUser refreshTokenUser);
        Task SetRevokedAllRefreshTokensUserByUserIdAsync(Guid userId);
    }
}
