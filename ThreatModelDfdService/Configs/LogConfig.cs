using Serilog;

namespace ThreatModelDfdService.Configs;

public static class LogConfig
{
    public static void AddSerilogConfiguration(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.Debug()
        .CreateLogger();
    }
}
