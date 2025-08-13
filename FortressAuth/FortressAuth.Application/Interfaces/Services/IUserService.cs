using FortressAuth.Application.DTOs.User;

namespace FortressAuth.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserDTO createUserDTO);
        Task<List<UserDTO>> GetAllUsersAsync(GetUserDTO getUserDTO);
    }
}
