using MerchantInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantApplication.Interfaces;
using MerchantInfrastructure.Repositories;
using MerchantApplication.Features.MerchantLocations.Interfaces;
using MerchantInfrastructure.MerchantLocationRepositories;
using MerchantApplication.Features.ManagementHierarchies.Interface;
using MerchantInfrastructure.ManagementHierarchyReositories;
using MerchantApplication.Features.AuthenticationJwt.Interface;
using MerchantInfrastructure.AuthenticationRepositories;
using MerchantApplication.Features.SignalR.Interface;
using MerchantInfrastructure.NotificationRepositories;
namespace MerchantInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // 🔹 Configure EF Core
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppDb")));

            // 🔹 Register Merchant Repository
            services.AddScoped<IMerchantRepository, MerchantRepository>();

            // 🔹 Register MerchantLocation Repository
            services.AddScoped<IMerchantLocationRepository, MerchantLocationRepository>();


            // 🔹 Register ManagementHierarchy Repository
            services.AddScoped<IManagementHierarchy, ManagementHierarchyRepository>();

            // 🔹 Register Authentication Repository
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

        
            // 🔹 Register SignalR Repository
            services.AddScoped<INotificationService, SignalRNotificationService>();
            //
            services.AddSignalR();
            return services;
        }
    }
}
