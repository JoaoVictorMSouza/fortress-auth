using FortressAuth.Domain.Entities;
using FortressAuth.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FortressAuth.Infraestructure.Data.Repositories
{
    public class RefreshTokenUserRepository : IRefreshTokenUserRepository
    {
        private SqlServerDbContext _sqlServerDbContext;

        public RefreshTokenUserRepository(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        public Task AddRefreshTokenUserAsync(RefreshTokenUser refreshToken)
        {
            _sqlServerDbContext.RefreshTokensUser.Add(refreshToken);
            return _sqlServerDbContext.SaveChangesAsync();
        }

        public Task<RefreshTokenUser?> GetRefreshTokenUserByTokenAndUserIdAsync(string token, Guid userId)
        {
            return _sqlServerDbContext.RefreshTokensUser.Include(x => x.User).FirstOrDefaultAsync(x => x.Token == token && x.UserId == userId);
        }

        public Task SetRevokedRefreshTokenUser(RefreshTokenUser refreshTokenUser)
        {
            _sqlServerDbContext.RefreshTokensUser.Update(refreshTokenUser);

            return _sqlServerDbContext.SaveChangesAsync();
        }

        public Task SetRevokedAllRefreshTokensUserByUserIdAsync(Guid userId)
        {
            var refreshTokens = _sqlServerDbContext.RefreshTokensUser.Where(x => x.UserId == userId && !x.Revoked).ToList();

            foreach (var refreshToken in refreshTokens)
            {
                refreshToken.SetRevoked();
            }

            _sqlServerDbContext.RefreshTokensUser.UpdateRange(refreshTokens);
            return _sqlServerDbContext.SaveChangesAsync();
        }
    }
}
