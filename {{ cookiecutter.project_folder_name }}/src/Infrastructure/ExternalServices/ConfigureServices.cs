namespace {{ cookiecutter.project_name.title() }}.Infrastructure.ExternalServices;

public static class ConfigureServices
{
    internal static IServiceCollection AddExternalServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}