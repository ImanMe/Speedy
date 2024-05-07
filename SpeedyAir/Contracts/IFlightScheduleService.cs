using SpeedyAir.Models;

namespace SpeedyAir.Contracts;

public interface IFlightScheduleService
{
    IList<FlightItinerary> GenerateFlightItineraries();
    void DisplayFlightsItineraryList(IList<FlightItinerary> flightItineraries);
}