var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;
{
    services.AddApplication()
    .AddInfrastructure(configuration)
    .AddApiServices(configuration)
    .AddShared(configuration);
}

var app = builder.Build();
{

    app.UseSwaggerConfig();
    
    app.UseHttpsRedirection();

    app.UseExceptionHandling();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}