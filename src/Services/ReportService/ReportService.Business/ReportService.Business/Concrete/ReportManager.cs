using ReportService.Business.Abstract;
using ReportService.Data.Contexts;
using ReportService.Data.Repositories.Concrete.EntityFramework;
using ReportService.Entity.DTOs;
using ReportService.Entity.Entities;

namespace ReportService.Business.Concrete
{
    public class ReportManager : IReportService
    {
        ReportRepository reportRepository = new ReportRepository(new ReportServiceContext());
        public Report ConvertToReport(ReportDto reportDto)
        {
            Report report = new Report();
            report.Id = reportDto.Id;
            report.ReportName = reportDto.ReportName;
            report.Location = reportDto.Location.ToUpper().ToLower();
            report.PersonCount = reportDto.PersonCount;
            report.PhoneCount = reportDto.PhoneCount;
            report.RequestedDate = reportDto.RequestedDate;
            report.status = reportDto.status;

            return report;
        }


        public ReportDto ConvertToDto(Report report)
        {
            ReportDto reportDto = new ReportDto();
            reportDto.Id = report.Id;
            reportDto.ReportName = report.ReportName;
            reportDto.PersonCount = report.PersonCount;
            reportDto.PhoneCount = report.PhoneCount;
            reportDto.RequestedDate = report.RequestedDate;
            reportDto.status = report.status;

            return reportDto;
        }


        public void AddReport(ReportDto reportDto)
        {
            Report report = ConvertToReport(reportDto);
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
