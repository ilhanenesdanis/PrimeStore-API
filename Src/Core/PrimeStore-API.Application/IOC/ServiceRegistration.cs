using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PrimeStore_API.Application.IOC
{
    public static class ServiceRegistration
    {
        public static void AddApplicationDependency(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
