using AutoMapper;
using ContactService.Entity.DTOs;
using ContactService.Entity.Entities;

namespace ContactService.Entity.AutoMapper.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();
        }
    }
}
