using AutoMapper;
using AutoMapper.Configuration;
using FortressAuth.Application.DTOs.User;
using FortressAuth.Domain.Entity;

namespace FortressAuth.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>()
                .ForMember(user => user.Email, iMemberConfigurationExpression => iMemberConfigurationExpression.MapFrom(userDto => userDto.Email))
                .ForMember(user => user.PasswordHash, iMemberConfigurationExpression => iMemberConfigurationExpression.MapFrom(userDto => userDto.Password))
                .ForMember(user => user.Description, iMemberConfigurationExpression => iMemberConfigurationExpression.MapFrom(userDto => userDto.Description));

            CreateMap<User, UserDTO>()
                .ForMember(userDto => userDto.Password, iMemberConfigurationExpression => iMemberConfigurationExpression.MapFrom(user => "*****"))
                .ForMember(userDto => userDto.InclusionDatetime, iMemberConfigurationExpression => iMemberConfigurationExpression.MapFrom(user => user.DhInclusion))
                .ForMember(userDto => userDto.ChangeDatetime, iMemberConfigurationExpression => iMemberConfigurationExpression.MapFrom(user => user.DhChange));
        }
    }
}
