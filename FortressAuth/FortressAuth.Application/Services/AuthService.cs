using FortressAuth.Application.DTOs.Auth;
using FortressAuth.Application.Interfaces.Security;
using FortressAuth.Application.Interfaces.Services;
using FortressAuth.Domain.Entity;
using FortressAuth.Domain.Interfaces;

namespace FortressAuth.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO, string ip)
        {
            User? user = await _userRepository.GetUserByEmailAsync(loginRequestDTO.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            if (!_passwordHasher.VerifyPassword(loginRequestDTO.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            DateTime accessTokenExpiry = _jwtService.GetExpirationAcessToken();
            DateTime refreshTokenExpiry = _jwtService.GetExpirationRefreshToken();

            string accessToken = _jwtService.GenerateAccessToken(user, accessTokenExpiry);

            string refreshToken = _jwtService.GenerateRefreshToken();

            return new LoginResponseDTO(
                accessToken, 
                new DateTimeOffset(accessTokenExpiry, TimeSpan.Zero).ToUnixTimeMilliseconds(), 
                refreshToken, 
                new DateTimeOffset(refreshTokenExpiry, TimeSpan.Zero).ToUnixTimeMilliseconds()
            );
        }
    }
}
