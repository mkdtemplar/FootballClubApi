using Contracts;
using Entities;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace FootballClubApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddScoped<ILoggerManager, LoggerManager>();

    public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlite(configuration.GetConnectionString("sqliteConn"), m =>
                m.MigrationsAssembly("FootballClubApi")));

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
}