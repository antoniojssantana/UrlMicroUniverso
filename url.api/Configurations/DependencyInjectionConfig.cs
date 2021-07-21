using Microsoft.Extensions.DependencyInjection;
using sga.utils;
using sga.utils.Interfaces;
using url.api.Interfaces;
using url.api.Services;
using url.business.Interfaces.Repository;
using url.business.Interfaces.Services;
using url.business.Notifications;
using url.business.Services;
using url.data.Context;
using url.data.Repository;

namespace url.api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<URLDbContext>();

            services.AddScoped<IUserBaseRepository, UserBaseRepository>();

            //Services
            services.AddScoped<IUserBaseService, UserBaseService>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailSender, EmailService>();

            //API
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}