using Microsoft.Extensions.DependencyInjection;
using ReportService.Data.Repositories.Abstract;
using ReportService.Data.Repositories.Concrete.EntityFramework;

namespace ReportService.Data
{
    public static class ServiceRegistration
    {
        public static void AddDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<IReportRepository, ReportRepository>();
        }

    }
}
