using SpeedyAir.Contracts;
using SpeedyAir.Models;

namespace SpeedyAir.Services;

public class FlightService : IFlightService
{
    /// <summary>
    ///     Load flight schedule from hardcoded data
    /// </summary>
    /// <returns>Flights</returns>
    /// Ideally to be replaced by a data store eg. Database
    public IList<Flight> LoadFlightsSchedule()
    {
        var flights = new List<Flight>
        {
            new(1, "Montreal (YUL)", "Toronto (YYZ)", 1),
            new(2, "Montreal (YUL)", "Calgary (YYC)", 1),
            new(3, "Montreal (YUL)", "Vancouver (YVR)", 1),
            new(4, "Montreal (YUL)", "Toronto (YYZ)", 2),
            new(5, "Montreal (YUL)", "Calgary (YYC)", 2),
            new(6, "Montreal (YUL)", "Vancouver (YVR)", 2)
        };
        return flights;
    }

    /// <summary>
    ///     Display flights details
    /// </summary>
    /// <param name="flights"></param>
    /// <returns></returns>
    public void DisplayFlights(IList<Flight> flights)
    {
        foreach (var flight in flights)
        {
            Console.WriteLine(flight.ToString());
        }
    }
}