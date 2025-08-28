using FortressAuth.Application.Interfaces.Services;
using FortressAuth.Domain.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FortressAuth.Infraestructure.Security
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(User user, DateTime expiresAtUtc)
        {
            ClaimsIdentity claims = GetClaims(user);
            SigningCredentials signingCredentials = GetSigningCredentials();

            return GenerateToken(claims, signingCredentials, expiresAtUtc);
        }

        public DateTime GetExpirationAcessToken()
        {
            var expirationAcessToken = _configuration["JWT:AccessTokenExpirationMinutes"];
            if (string.IsNullOrWhiteSpace(expirationAcessToken) || !int.TryParse(expirationAcessToken, out int expirationMinutes))
            {
                throw new ArgumentException("Invalid or missing JWT:AccessTokenExpirationMinutes configuration.");
            }

            DateTime expirationAcessTokenDatetime = DateTime.UtcNow.AddMinutes(expirationMinutes);

            return expirationAcessTokenDatetime;
        }

        public DateTime GetExpirationRefreshToken()
        {
            var expirationRefreshToken = _configuration["JWT:RefreshTokenExpirationMinutes"];
            if (string.IsNullOrWhiteSpace(expirationRefreshToken) || !int.TryParse(expirationRefreshToken, out int expirationMinutes))
            {
                throw new ArgumentException("Invalid or missing JWT:RefreshTokenExpirationMinutes configuration.");
            }

            DateTime expirationRefreshTokenDatetime = DateTime.UtcNow.AddMinutes(expirationMinutes);

            return expirationRefreshTokenDatetime;
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

        private string GenerateToken(ClaimsIdentity claims, SigningCredentials signingCredentials, DateTime expiresAtUtc)
        {
            var handler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredentials,
                Expires = expiresAtUtc,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Subject = claims
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!);
            return new SymmetricSecurityKey(key);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]!);

            return new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
        }

        private ClaimsIdentity GetClaims(User user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Name));

            return claimsIdentity;
        }

        public ClaimsPrincipal GetPayloadClaimsPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSymmetricSecurityKey(),
                ValidateLifetime = false
            };

            var handler = new JwtSecurityTokenHandler();

            var principal = handler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            ValidateSecurityToken(securityToken);

            return principal;
        }

        private void ValidateSecurityToken(SecurityToken securityToken)
        {
            if (securityToken is not JwtSecurityToken jwt || !jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
        }
    }
}
