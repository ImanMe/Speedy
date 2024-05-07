using SpeedyAir.Models;

namespace SpeedyAir.Contracts;

public interface IFlightService
{
    public IList<Flight> LoadFlightsSchedule();
    void DisplayFlights(IList<Flight> flights);
}