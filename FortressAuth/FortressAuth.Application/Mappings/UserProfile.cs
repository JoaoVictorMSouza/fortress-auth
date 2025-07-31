using AutoMapper;
using FortressAuth.Application.DTOs.User;
using FortressAuth.Domain.Entity;

namespace FortressAuth.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>()
                .ForMember(user => user.Email, c => c.MapFrom(userDto => userDto.Email))
                .ForMember(user => user.PasswordHash, c => c.MapFrom(userDto => userDto.Password))
                .ForMember(user => user.Description, c => c.MapFrom(userDto => userDto.Description));
        }
    }
}
