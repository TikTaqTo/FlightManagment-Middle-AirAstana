using Application.Abstractions;
using Infrastructure.Database;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAirportService, AirportService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddDbContext<ApplicationContext>();

        return services;
    }
}