﻿using KHRMS.Core;
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
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IAssetsMasterRepository, AssetsMasterRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IProjectMasterRepository, ProjectMasterRepository>();
            services.AddScoped<IUserRegistrationRepository, UserRegistrationRepository>();

            return services;
        }
    }
}
