using AutoMapper;
using ReportService.Business.Abstract;
using ReportService.Data.Contexts;
using ReportService.Data.Repositories.Concrete.EntityFramework;
using ReportService.Entity.DTOs;
using ReportService.Entity.Entities;

namespace ReportService.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IMapper _mapper;

        public ReportManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        ReportRepository reportRepository = new ReportRepository(new ReportServiceContext());


        public void AddReport(ReportDto reportDto)
        {
            var report = _mapper.Map<Report>(reportDto);
            reportRepository.AddReport(report);
        }

        public List<ReportDto> GetReports()
        {
            List<Report> reports = reportRepository.GetReports();

            List<ReportDto> reportDtos = new List<ReportDto>();

            foreach (Report r in reports)
            {
                ReportDto reportDto = new ReportDto();
                reportDto.Id = r.Id;
                reportDto.Location = r.Location;
                reportDto.ReportName = r.ReportName;
                reportDto.PersonCount = r.PersonCount;
                reportDto.PhoneCount = r.PhoneCount;
                reportDto.status = r.status;

                reportDtos.Add(reportDto);

            }


            return reportDtos;
        }



        public void DeleteReport(Guid Id)
        {
            Report report = reportRepository.GetReportById(Id);
            reportRepository.DeleteReport(report);
        }

    }
}
