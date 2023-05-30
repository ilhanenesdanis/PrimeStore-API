using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrimeStore_API.Application.Repositorys.Dapper;
using PrimeStore_API.Application.UnitOfWork;
using PrimeStore_API.Persistence.Repositorys.Dapper;
using System.Reflection;

namespace PrimeStore_API.Persistence.IOC
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Persistence.Context.ApplicationContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("SqlConnection"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetAssembly(typeof(Persistence.Context.ApplicationContext)).GetName().Name);
                })
            );

            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
