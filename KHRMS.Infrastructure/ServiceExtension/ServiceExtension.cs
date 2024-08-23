using KHRMS.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace KHRMS.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KHRMSContextClass>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HRMSContext"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();

            return services;
        }
    }
}
