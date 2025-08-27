using FortressAuth.Domain.Entities.Base;
using FortressAuth.Domain.Entity;

namespace FortressAuth.Domain.Entities
{
    public class RefreshTokenUser : DefaultEntityGuid
    {
        public string Token { get; private set; }
        public DateTime ExpiresAtUtc { get; private set; }
        public bool Revoked { get; private set; }
        public string? ReplacedByToken { get; private set; }

        public User User { get; private set; }

        public bool IsActive => !Revoked && DateTime.UtcNow < ExpiresAtUtc;

        public void SetRevoked(string? replacedByToken = null)
        {
            Revoked = true;
            Token = null!;
            ReplacedByToken = replacedByToken;
        }
    }
}
