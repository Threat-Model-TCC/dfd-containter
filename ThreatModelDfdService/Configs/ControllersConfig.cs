namespace ThreatModelDfdService.Configs;

public static class ControllersConfig
{
    public static void AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options
            .JsonSerializerOptions.Converters
            .Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        });
    }
}
