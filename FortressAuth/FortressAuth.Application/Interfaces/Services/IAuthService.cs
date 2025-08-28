using FortressAuth.Application.DTOs.Auth;

namespace FortressAuth.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO, string ip);
        Task<RefreshTokenResponseDTO> RefreshAsync(RefreshTokenRequestDTO refreshTokenRequestDTO);
    }
}
