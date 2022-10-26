using Microsoft.Extensions.DependencyInjection;
using ReportService.Business.Abstract;
using ReportService.Business.Concrete;

namespace ReportService.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportManager>();
        }
    }
}