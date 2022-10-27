using AutoMapper;
using ContactService.Entity.DTOs;
using ContactService.Entity.Entities;

namespace ContactService.Entity.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
