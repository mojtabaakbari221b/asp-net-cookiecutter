namespace {{ cookiecutter.project_name.title() }}.Infrastructure.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}