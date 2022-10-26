using ReportService.Entity.DTOs;

namespace ReportService.Business.Abstract
{
    public interface IReportService
    {
        void AddReport(ReportDto reportDto);
        List<ReportDto> GetReports();
        void DeleteReport(Guid id);
    }
}
