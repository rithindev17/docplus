using MedicalImagingService.APIs;

namespace MedicalImagingService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IDiseasesService, DiseasesService>();
        services.AddScoped<IPatientsService, PatientsService>();
        services.AddScoped<IResultsService, ResultsService>();
        services.AddScoped<IScansService, ScansService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
