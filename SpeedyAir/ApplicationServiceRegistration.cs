using Microsoft.Extensions.DependencyInjection;
using SpeedyAir.Contracts;
using SpeedyAir.Services;

namespace SpeedyAir;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddSpeedyAirServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IOrderService, OrderService>()
            .AddTransient<IFlightScheduleService, FlightScheduleService>()
            .AddTransient<IFlightService, FlightService>();
    }
}