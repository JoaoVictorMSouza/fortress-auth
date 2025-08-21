using FortressAuth.Application.DTOs.Auth;
using FortressAuth.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FortressAuth.Controllers
{
    [ApiController, Route("[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            var loginResponseDTO = await _authService.LoginAsync(dto, ip);

            return Ok(loginResponseDTO);
        }
    }
}
