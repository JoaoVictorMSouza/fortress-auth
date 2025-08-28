namespace FortressAuth.Application.DTOs.Auth
{
    public class RefreshTokenResponseDTO
    {
        public RefreshTokenResponseDTO(string accessToken, long accessTokenExpiry, string refreshToken, long refreshTokenExpiry)
        {
            AccessToken = accessToken;
            AccessTokenExpiry = accessTokenExpiry;
            RefreshToken = refreshToken;
            RefreshTokenExpiry = refreshTokenExpiry;
        }

        public string AccessToken { get; set; }
        public long AccessTokenExpiry { get; set; }
        public string RefreshToken { get; set; }
        public long RefreshTokenExpiry { get; set; }
    }
}
