using ReportService.Data.Contexts;
using ReportService.Data.Repositories.Abstract;
using ReportService.Entity.Entities;

namespace ReportService.Data.Repositories.Concrete.EntityFramework
{
    public class ReportRepository: IReportRepository
    {
        protected ReportServiceContext _reportContext;
        public ReportRepository(ReportServiceContext context)
        {
            _reportContext = context;
        }


        public void AddReport(Report report)
        {
            _reportContext.Reports.Add(report);
            _reportContext.SaveChanges();
        }


        public List<Report> GetReports()
        {
            return _reportContext.Reports.ToList();
        }

        public Report GetReportById(Guid id)
        {
            return _reportContext.Reports.FirstOrDefault(x => x.Id == id);
        }
        public void DeleteReport(Report report)
        {
            _reportContext.Reports.Remove(report);
            _reportContext.SaveChanges();
        }

    }
}
