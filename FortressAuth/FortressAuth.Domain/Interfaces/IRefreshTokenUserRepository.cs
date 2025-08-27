using FortressAuth.Domain.Entities;

namespace FortressAuth.Domain.Interfaces
{
    public interface IRefreshTokenUserRepository
    {
        Task<RefreshTokenUser?> GetRefreshTokenUserByTokenAsync(string token);
        Task AddRefreshTokenUserAsync(RefreshTokenUser refreshToken);
        Task RevokeRefreshTokenUserByTokenAsync(string token);
        Task RevokeAllRefreshTokensUserByUserIdAsync(Guid userId);
    }
}
