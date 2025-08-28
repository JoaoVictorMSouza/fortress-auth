using FortressAuth.Domain.Entities;

namespace FortressAuth.Domain.Interfaces
{
    public interface IRefreshTokenUserRepository
    {
        Task<RefreshTokenUser?> GetRefreshTokenUserByTokenAndUserIdAsync(string token, Guid userId);
        Task AddRefreshTokenUserAsync(RefreshTokenUser refreshToken);
        Task SetRevokedRefreshTokenUser(RefreshTokenUser refreshTokenUser);
        Task SetRevokedAllRefreshTokensUserByUserIdAsync(Guid userId);
    }
}
