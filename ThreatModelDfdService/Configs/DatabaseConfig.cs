using Microsoft.EntityFrameworkCore;
using ThreatModelDfdService.Model.Context;

namespace ThreatModelDfdService.Configs;

public static class DatabaseConfig
{
    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException("SQL Server connection string not found.");
        }
        services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
