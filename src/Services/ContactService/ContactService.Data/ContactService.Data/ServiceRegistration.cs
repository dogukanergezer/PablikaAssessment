using ContactService.Data.Abstract;
using ContactService.Data.Repositories.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace ContactService.Data
{
    public static class ServiceRegistration
    {
        public static void AddDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }

    }
}
