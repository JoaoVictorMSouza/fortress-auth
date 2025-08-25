using FluentValidation;
using FortressAuth.Application.DTOs.Responses.Erro;
using FortressAuth.Application.DTOs.User;
using FortressAuth.Application.Interfaces.Services;
using FortressAuth.Filters.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace FortressAuth.Controllers
{
    [ApiController, Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create"), AuthorizeUserAttribute]
        public async Task<IActionResult> CreateUser([FromServices] IValidator<CreateUserDTO> validator, [FromBody] CreateUserDTO createUserDTO)
        {
            var validationResult = await validator.ValidateAsync(createUserDTO);

            if (!validationResult.IsValid)
            {
                throw new CustomException("Validation error", validationResult.Errors.Select(x => x.ErrorMessage));
            }

            await _userService.CreateUserAsync(createUserDTO);

            return Ok();
        }

        [HttpGet("get-all"), AuthorizeUserAttribute]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUserDTO getUserDTO)
        {
            var users = await _userService.GetAllUsersAsync(getUserDTO);

            return Ok(users);
        }
    }
}
