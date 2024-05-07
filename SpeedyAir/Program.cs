using Microsoft.Extensions.DependencyInjection;
using SpeedyAir.Contracts;

namespace SpeedyAir;

public class Program
{
    private static void Main()
    {
        // Set up DI container
        var serviceProvider = new ServiceCollection()
            .AddSpeedyAirServices()
            .BuildServiceProvider();

        Console.WriteLine("*************** List of flights - User story 1 ***************");

        DisplayFlightSchedules(serviceProvider);

        Console.WriteLine("*************** Flight Itineraries - User story 2 ***************");

        GenerateFlightItineraries(serviceProvider);
    }

    private static void DisplayFlightSchedules(IServiceProvider serviceProvider)
    {
        var flightService = serviceProvider.GetService<IFlightService>();

        var flights = flightService.LoadFlightsSchedule();

        flightService.DisplayFlights(flights);
    }

    private static void GenerateFlightItineraries(IServiceProvider serviceProvider)
    {
        var flightScheduleService = serviceProvider.GetService<IFlightScheduleService>();

        var flightItineraryList = flightScheduleService.GenerateFlightItineraries();

        flightScheduleService.DisplayFlightsItineraryList(flightItineraryList);
    }
}