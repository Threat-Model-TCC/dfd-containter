using EvolveDb;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Serilog;

namespace ThreatModelDfdService.Configs;

public static class EvolveConfig
{
    public static IServiceCollection AddEvolveConfiguration(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        if(environment.IsDevelopment())
        {
            var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("SQL Server connection string not found.");
            }
            
            try
            {
                using var evolveConnection = new SqlConnection(connectionString);
                var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch(Exception exc)
            {
                Log.Error(exc, "Error ocurred while migrating the database.");
                throw;
            }
        }

        return services;
    }
}
