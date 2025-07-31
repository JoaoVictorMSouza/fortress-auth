using FluentValidation;
using FortressAuth.Application.DTOs.User;
using FortressAuth.Application.Interfaces.Services;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromServices] IValidator<CreateUserDTO> validator, [FromBody] CreateUserDTO createUserDTO)
        {
            var validationResult = await validator.ValidateAsync(createUserDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _userService.CreateUserAsync(createUserDTO);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("An error occurred while creating the user. Please try again later.");
            }
        }
    }
}
