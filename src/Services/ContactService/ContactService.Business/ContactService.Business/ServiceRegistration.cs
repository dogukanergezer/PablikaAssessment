
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ContactService.Business.Abstract;
using ContactService.Business.Concrete;

namespace ContactService.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IContactService, ContactManager>();
        }

    }
}
