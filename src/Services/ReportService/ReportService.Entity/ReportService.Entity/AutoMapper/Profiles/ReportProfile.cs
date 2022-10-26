using AutoMapper;
using ReportService.Entity.DTOs;
using ReportService.Entity.Entities;

namespace ReportService.Entity.AutoMapper.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportDto, Report>().ReverseMap();
        }
    }
}
