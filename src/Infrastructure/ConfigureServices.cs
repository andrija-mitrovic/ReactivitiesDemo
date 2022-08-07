using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        private const string CONNECTION_STRING_NAME = "DefaultConnection";

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString(CONNECTION_STRING_NAME),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped<ApplicationDbContextInitialiser>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();

            return services;
        }
    }
}
