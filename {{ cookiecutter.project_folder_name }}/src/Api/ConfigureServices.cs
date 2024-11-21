namespace {{ cookiecutter.project_name.title() }}.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Envs", ".Env");
        Env.Load(envFilePath);
        configuration.AddEnvironmentVariables();

        configuration["ConnectionStrings:DefaultConnection"] = configuration["CONNECTION_STRING"];
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfig();
        
        return services;
    }
    private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your token."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });
        });


        return services;
    }
}