using AutoMapper;
using FortressAuth.Application.DTOs.Responses.Erro;
using FortressAuth.Application.DTOs.User;
using FortressAuth.Application.Interfaces.Services;
using FortressAuth.Domain.Entity;
using FortressAuth.Domain.Interfaces;

namespace FortressAuth.Application.Services
{
    public class UserService : IUserService
    {
        public IMapper _mapper { get; set; }
        public IUserRepository _userRepository { get; set; }
        public IPasswordHasher _passwordHasher { get; set; }
        public UserService(IMapper mapper, IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateUserAsync(CreateUserDTO createUserDTO)
        {
            User? user = await _userRepository.GetUserByEmailAsync(createUserDTO.Email);

            if (user != null)
            {
                throw new CustomException("User with this email already exists.");
            }

            User newUser = _mapper.Map<User>(createUserDTO);

            string passwordHash = _passwordHasher.HashPassword(createUserDTO.Password);

            newUser.SetNewPasswordHash(passwordHash);

            newUser.SetRoleUser();

            await _userRepository.AddUserAsync(newUser);
        }
    }
}
