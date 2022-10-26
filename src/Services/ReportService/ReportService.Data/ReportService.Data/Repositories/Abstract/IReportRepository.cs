using ReportService.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Data.Repositories.Abstract
{
    public interface IReportRepository
    {
        void AddReport(Report report);
        List<Report> GetReports();
        Report GetReportById(Guid id);
        void DeleteReport(Report report);
    }
}
