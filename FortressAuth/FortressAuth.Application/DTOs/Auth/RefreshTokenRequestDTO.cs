namespace FortressAuth.Application.DTOs.Auth
{
    public class RefreshTokenRequestDTO
    {
        public string RefreshToken { get; set; }
        public string AcessToken { get; set; }
    }
}
