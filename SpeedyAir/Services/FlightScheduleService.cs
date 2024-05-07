using SpeedyAir.Contracts;
using SpeedyAir.Models;

namespace SpeedyAir.Services;

public class FlightScheduleService : IFlightScheduleService
{
    private const int MaxOrderCapacityPerFlight = 20;
    private readonly IFlightService _flightService;
    private readonly IOrderService _orderService;

    public FlightScheduleService(IFlightService flightService, IOrderService orderService)
    {
        _flightService = flightService;
        _orderService = orderService;
    }

    /// <summary>
    /// Generate flight itineraries
    /// </summary>
    /// <returns></returns>
    public IList<FlightItinerary> GenerateFlightItineraries()
    {
        var flights = _flightService.LoadFlightsSchedule();
        var orders = _orderService.LoadOrders("OrderMock.json");

        var flightItineraryList = new List<FlightItinerary>();

        foreach (var order in orders)
        {
            var orderAssigned = false;
            foreach (var flight in flights)
                if (flight.AssignedOrders.Count < MaxOrderCapacityPerFlight) // Check flight capacity
                {
                    flight.AssignedOrders.Add(order);

                    var flightItinerary = new FlightItinerary(order.OrderId, flight.Number, flight.DepartureCity,
                        flight.ArrivalCity, flight.Day);

                    flightItineraryList.Add(flightItinerary);
                    orderAssigned = true;
                    break;
                }

            if (!orderAssigned)
            {
                // Create a non-scheduled itinerary
                var flightItinerary = new FlightItinerary(order.OrderId);

                flightItineraryList.Add(flightItinerary);
            }
        }

        return flightItineraryList;
    }

    /// <summary>
    /// Print flights itineraries
    /// </summary>
    /// <param name="flightItineraries"></param>
    public void DisplayFlightsItineraryList(IList<FlightItinerary> flightItineraries)
    {
        foreach (var flightItinerary in flightItineraries)
        {
            Console.WriteLine(flightItinerary.ToString());
        }
    }
}