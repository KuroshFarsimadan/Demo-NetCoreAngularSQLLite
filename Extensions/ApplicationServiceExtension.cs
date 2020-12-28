using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MontrealDatingApp.Data;
using MontrealDatingApp.Helpers;
using MontrealDatingApp.Interfaces;
using MontrealDatingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MontrealDatingApp.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration config
            )
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            // Add the database context configuration and connection string
            services.AddDbContext<DataContext>(options =>
            {
                // Get our connection string from appsettings.json
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ITokenService, TokenService>();
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            /*services.AddDbContext<DataContext>(
                options =>
                {
                    options.UseSqlite(config.GetConnectionString("DefaultConnection"));
                }
            );*/
            
            return services;
        }
    }
}
